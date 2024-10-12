using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.DataTransferObjects.Collection
{
    public class CollectionResult<T>
    {
        public CollectionResult()
        {
        }

        public CollectionResult(T result)
        {
            this.Result = result;
            this.Status = new CollectionResultStatus();
        }

        public CollectionResult(bool isAuth, string error)
        {
            var errorMsgs = new List<CollectionResultMessage>() { new CollectionResultMessage(Enum.ResultMessageType.Danger, error) };
            this.Status = new CollectionResultStatus(isAuth, false, errorMsgs);
        }

        public CollectionResult(bool isAuth, List<string> errors)
        {
            var errorMsgs = errors.Select(e => new CollectionResultMessage(Enum.ResultMessageType.Danger, e)).ToList();
            this.Status = new CollectionResultStatus(isAuth, false, errorMsgs);
        }

        public CollectionResult(bool isAuth, bool isSuccess, List<CollectionResultMessage> messageList)
        {
            this.Status = new CollectionResultStatus(isAuth, isSuccess, messageList);
        }

        public CollectionResult(bool isAuth, bool isSuccess, T result)
        {
            this.Status = new CollectionResultStatus(isAuth, isSuccess, null);
            this.Result = result;
        }

        public CollectionResult(bool isAuth, bool isSuccess, T result, List<CollectionResultMessage> messageList)
        {
            this.Status = new CollectionResultStatus(isAuth, isSuccess, messageList);
            this.Result = result;
        }

        public CollectionResultStatus? Status { get; set; }
        public T? Result { get; set; }

    }
}
