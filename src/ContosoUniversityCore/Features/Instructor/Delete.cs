﻿namespace ContosoUniversityCore.Features.Instructor
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using Domain;
    using Infrastructure;
    using MediatR;

    public class Delete
    {
        public class Query : IAsyncRequest<Command>
        {
            public int? Id { get; set; }
        }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(m => m.Id).NotNull();
            }
        }

        public class Command : IAsyncRequest
        {
            public int? ID { get; set; }

            public string LastName { get; set; }
            [Display(Name = "First Name")]
            public string FirstMidName { get; set; }

            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
            public DateTime? HireDate { get; set; }

            [Display(Name = "Location")]
            public string OfficeAssignmentLocation { get; set; }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, Command>
        {
            private readonly SchoolContext _db;

            public QueryHandler(SchoolContext db)
            {
                _db = db;
            }

            public async Task<Command> Handle(Query message)
            {
                return await _db.Instructors.Where(i => i.Id == message.Id).ProjectToSingleOrDefaultAsync<Command>();
            }
        }

        public class CommandHandler : AsyncRequestHandler<Command>
        {
            private readonly SchoolContext _db;

            public CommandHandler(SchoolContext db)
            {
                _db = db;
            }

            protected override async Task HandleCore(Command message)
            {
                Instructor instructor = await _db.Instructors
                    .Include(i => i.OfficeAssignment)
                    .Where(i => i.Id == message.ID)
                    .SingleAsync();

                instructor.OfficeAssignment = null;
                _db.Instructors.Remove(instructor);

                var department = await _db.Departments
                    .Where(d => d.InstructorID == message.ID)
                    .SingleOrDefaultAsync();
                if (department != null)
                {
                    department.InstructorID = null;
                }

            }
        }
    }

}