using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DTO.Employee
{
    public class LocationInfoDto
    {
        public record CreateLocationInfoDto(
            [Required] long UserId,
            [Required] long CityId,
            [Required] long StateId,
            [Required] long CountryId,
            [Required] long TrainLineId,
            [Required] string AddressLine1,
            string AddressLine2,
            long ZipCode
        );
        public record GetLocationInfoDto(
            long Id,
            string Email,
            string City,
            string State,
            string Country,
            string TrainLine,
            string AddressLine1,
            string AddressLine2,
            long ZipCode
        );
        public record UpdateLocationInfoDto(
            long Id,
            long UserId,
            long CityId,
            long StateId,
            long CountryId,
            long TrainLineId,
            string AddressLine1,
            string AddressLine2,
            long ZipCode
        );
    }
}
