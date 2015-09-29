module HttpResponseHelpers

open System
open System.Net
open System.Net.Http

let okWithStringContent contentType (content:string) = 
    let response = new HttpResponseMessage(HttpStatusCode.OK)
    response.Content <- new StringContent(content)
    response.Content.Headers.ContentType <- new System.Net.Http.Headers.MediaTypeHeaderValue(contentType)
    response.Content.Headers.ContentLength <- Nullable<_>(int64 content.Length)
    response
