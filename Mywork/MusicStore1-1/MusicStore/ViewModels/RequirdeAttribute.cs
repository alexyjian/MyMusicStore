using System;

namespace MusicStore.ViewModels
{
    internal class RequirdeAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}