using Domain.DataTransferObjects.Collection.Enum;

namespace Domain.DataTransferObjects.Collection
{
    public class CollectionResultMessage
    {
        public CollectionResultMessage() {
            this.Type = ResultMessageType.Danger;
            this.Comment = string.Empty;
        }

        public CollectionResultMessage(ResultMessageType type, string comment)
        {
            this.Type = type;
            this.Comment = comment;
        }

        public ResultMessageType Type { get; set; }
        public string Comment { get; set; }

    }
}
