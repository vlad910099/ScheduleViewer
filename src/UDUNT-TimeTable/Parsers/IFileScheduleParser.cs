using Domain.Enums;
using System.Threading.Tasks;

namespace Main.Parsers
{
    public interface IFileScheduleParser
    {
        Task<ParseResult> Parse(byte[] fileData, FileType fileType, string scheduleName);
    }
}