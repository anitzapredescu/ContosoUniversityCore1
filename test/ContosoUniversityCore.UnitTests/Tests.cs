namespace ContosoUniversityCore.UnitTests
{
    using AutoMapper;
    using Shouldly;

    public class AutoMapperTests
    {
        // this parameter is needed so that the initialization code
        // (automapper config) runs
        public void Should_have_valid_configuration(ContainerFixture fixture) 
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
