using System;
using System.Collections.Generic;
using System.Text;

namespace Day1Training.Services
{
    public interface ITextToSpeech
    {
        void Speak(string _text);
    }
}
