﻿namespace Faker.Generators
{
    using System;
    using System.Text;
    using System.Linq;

    /// <summary>
    /// A generator for text data.
    /// </summary>
    public class StringGenerator : IGenerator
    {
        public Type[] MockedTypes
        {
            get { return new Type[] { typeof(string) }; }
        }

        public bool CanCreate(string name, Type type)
        {
            return this.MockedTypes.Contains(type);
        }

        /// <summary>
        /// Creates a random word.
        /// </summary>
        /// <returns></returns>
        public string CreateWord()
        {
            return Constants.AllWords[Faker.Random.Next(0, Constants.AllWords.Length)].ToLower();
        }

        /// <summary>
        /// Creates a random name.
        /// </summary>
        /// <returns></returns>
        public string CreateName()
        {
            var word = this.CreateWord();

            return char.ToUpper(word[0]) + word.Substring(1);
        }

        /// <summary>
        /// Creates a random title sentence.
        /// </summary>
        /// <returns></returns>
        public string CreateTitle(int words = 0)
        {
            if (words <= 0)
                words = Faker.Random.Next(5, 20);
            
            StringBuilder result = new StringBuilder(this.CreateName());

            for (int i = 1; i < words; i++)
            {
                result.Append(" " + this.CreateWord());
            }

            return result.ToString();
        }

        /// <summary>
        /// Creates a random sentence.
        /// </summary>
        /// <returns></returns>
        public string CreateSentence(int words = 0)
        {
            return this.CreateTitle(words) + ".";
        }

        /// <summary>
        /// Creates a random paragraph.
        /// </summary>
        /// <returns></returns>
        public string CreateParagraph(int sentences = 0)
        {
            if (sentences <= 0)
                sentences = Faker.Random.Next(2, 8);


            StringBuilder result = new StringBuilder(this.CreateSentence());

            for (int i = 1; i < sentences; i++)
            {
                result.Append(" " + this.CreateSentence());
            }

            return result.ToString();
        }

        /// <summary>
        /// Creates a random email address.
        /// </summary>
        /// <returns></returns>
        public string CreateEmail()
        {
            return String.Format("{0}.{1}@{2}.com", this.CreateWord(), this.CreateWord(), this.CreateWord());
        }

        public string CreateLink()
        {
            return String.Format("http://www.bing.com/search?q={0}", this.CreateWord());
        }

        public string CreateHexColor()
        {
            var bytes = new byte[3];
            Faker.Random.NextBytes(bytes);
            return "#" + BitConverter.ToString(bytes).Replace("-", string.Empty);
        }

        public string CreateImageLink()
        {
            return "http://lorempixel.com/500/500/";
        }

        public object Create(string name, Type type)
        {
            name = name.ToLower().Trim();

            if (name == "id" || 
                name == "key"||
                name == "identifier")
                return this.CreateWord();

            if (name.Contains("email"))
                return this.CreateEmail();

            if (name.Contains("color"))
                return this.CreateHexColor();

            if (name.Contains("name"))
                return this.CreateName();

            if (name.Contains("description") || name.Contains("summary"))
                return this.CreateParagraph();

            if (name.Contains("link") || 
                name.Contains("uri") || 
                name.Contains("url"))
            {
                if (name.Contains("image") ||
                    name.Contains("photo") ||
                    name.Contains("icon") || 
                    name.Contains("avatar") || 
                    name.Contains("screenshot"))
                {
                    return CreateImageLink();
                }

                return this.CreateLink();
            }

            if (name.Contains("title"))
                return this.CreateTitle();

            return this.CreateSentence();
        }

        
    }
}