﻿using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T? Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string>? Errors { get; set; }

        // Static Factory Methods
        public static CustomResponseDto<T> Success(int statusCode, T? data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errrors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errrors };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string>() { error } };
        }
    }
}