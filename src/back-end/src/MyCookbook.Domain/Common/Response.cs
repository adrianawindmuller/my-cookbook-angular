namespace MyCookbook.Domain.Common
{
    public class Response
    {
        public Response(ResponseType responseType, string messenge)
        {
            Message = messenge;
            ResponseType = responseType;
        }

        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public Response(ResponseType responseType, object data)
        {
            ResponseType = responseType;
            Data = data;
        }

        public string Message { get; }

        public ResponseType ResponseType { get; }

        public object Data { get; }

        public static Response NotFound(string message) => new Response(ResponseType.NotFound, message);

        public static Response BadRequest() => new Response(ResponseType.BadRequest);

        public static Response NoContent() => new Response(ResponseType.NoContent);

        public static Response Created(object data) => new Response(ResponseType.Created, data);

        public static Response Ok(object data) => new Response(ResponseType.Ok, data);
    }
}
