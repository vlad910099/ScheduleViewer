using System.Threading.Tasks;

namespace Core.Parsers
{
    public interface IFileScheduleParser
    {
        Task<ParseResult> Parse(byte[] fileData, FileType fileType, string scheduleName);
    }
}