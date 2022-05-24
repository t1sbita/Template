namespace Template.Api.Models.DTO
{
    /// <summary>
    /// AdressDto
    /// </summary>
    public class AdressDto : BaseDto
    {
        /// <summary>
        /// AdressDto.Number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// AdressDto.DescriptionAdress
        /// </summary>
        public string DescriptionAdress { get; set; }

        /// <summary>
        /// AdressDto.Complement
        /// </summary>
        public string Complement { get; set; }

        /// <summary>
        /// AdressDto.Neighborhood
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// AdressDto.ZipCode
        /// </summary>
        public long ZipCode { get; set; }

        /// <summary>
        /// AdressDto.City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// AdressDto.State
        /// </summary>
        public string State { get; set; }
    }
}
