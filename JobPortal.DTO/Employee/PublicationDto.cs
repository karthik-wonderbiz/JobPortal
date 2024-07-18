using System;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data
{
    public class PublicationDto
    {
    }

    public record CreatePublicationDto(
        [Required(ErrorMessage = "Publication Title is required")] string PublicationTitle,
        [Required(ErrorMessage = "Publisher Name is required")] string PublisherName,
        [Required(ErrorMessage = "Publication Date is required")] DateTime PublishDate,
        [Required(ErrorMessage = "Publication URL is required")] string PublicationURL,
        [Required(ErrorMessage = "Description is required")] string Description,
        [Required(ErrorMessage = "UserId is required")] long UserId,
        DateTime CreatedAt,
        DateTime UpdatedAt);

    public record UpdatePublicationDto(
        [Required(ErrorMessage = "Id is required")] string Id,
        [Required(ErrorMessage = "Publication Title is required")] string PublicationTitle,
        [Required(ErrorMessage = "Publisher is required")] string PublisherName,
        [Required(ErrorMessage = "Publication Date is required")] DateTime PublishDate,
        [Required(ErrorMessage = "Publication URL is required")] string PublicationURL,
        [Required(ErrorMessage = "Description is required")] string Description,
        [Required(ErrorMessage = "UserId is required")] long UserId,
        bool IsActive,
        DateTime UpdatedAt);

    public record GetPublicationDto(
        long Id,
        string PublicationTitle,
        string PublisherName,
        DateTime PublishDate,
        string PublicationURL,
        long UserId,
        string Description,
        bool IsActive);
}
