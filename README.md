# "Hello World" Code Variations Repository
This repository is dedicated to exploring the many unique ways that code can be written to output the classic "Hello World" message. The goal of this project is to showcase the diversity of the C# programming languages and it's paradigms, and to inspire creativity and experimentation in coding.

# How to Use This Repository
To get started with this repository, simply browse the existing submissions to see how different programmers have tackled the "Hello World" challenge. You can also submit your own variations by forking the repository and creating a new branch for your variation.

Once you've created your variation, submit a pull request to have it reviewed by the repository owners. Please be sure to include a brief description of your variation and the programming language or paradigm you used, include author details in your code.

Current implementations and details are currently found in the **Set01.cs** file in the **ManyHellos** project.

# Guidelines
To ensure that all submissions are relevant and appropriate, please adhere to the following guidelines when contributing to this repository:

* Each variation must output the string "Hello World" in some way.
* Variations nmeed to be written in the C# programming language.
* Variations should be unique and distinct from existing submissions.
* Refrain from using external resources like disk and cloud.
* Generally speaking, generate all conditions within the same class being submitted. 

The repository owners reserve the right to remove any submissions that are deemed inappropriate or violate these guidelines.

# Resources
Looking for inspiration or help getting started with a new programming language? Check out these resources:

* W3Schools - a great resource for learning the basics of many programming languages
* Codecademy - offers interactive coding lessons and projects for many popular programming languages
* Stack Overflow - a popular Q&A site for programmers of all skill levels

# Contributing
If you'd like to contribute to this repository, we'd love to see your unique take on the "Hello World" program! Simply fork the repository, create a new branch for your variation, and submit a pull request.

If you have any questions or concerns, please feel free to reach out to the repository owners.

License
This repository is licensed under the MIT License. See the LICENSE file for more information.

# Code Example and Explanation
The following class function SayHello() returns "Hello World" by using a compressed set of Indexes used in waht is called a DeBruijn sequence. Iterating through these sequences eventually create the conditions to extract the string "Hello World"


```csharp
    public class ByDeBruijn : HelloWorld
    {
        public override string SayHello()
        {
            char[] rtn = new char[11];

            string hex_index = "729A5610";

            string octal_index = Convert.ToString(Convert.ToInt32("65B82DEB", 16), 8);

            var compressed_indexes = new long[4] { 2126, 8622, 101677, 68889532 };
            var index_length = new int[4] { 4, 4, 5, 7 };

            var cIndex = new int[hex_index.Length];

            for (int i = 0; i < hex_index.Length; i++)
            {
                string key = string.Concat(Enumerable.Repeat(Convert.ToString(compressed_indexes[0], 2), 2));
                int idx = Convert.ToInt32(hex_index[i].ToString(), 16);
                string bits = key.Substring(idx, index_length[0]);
                cIndex[i] = Convert.ToInt32(bits, 2);
            }

            for (int x = 1; x < hex_index.Length / 2; x++)
            {
                string key = string.Concat(Enumerable.Repeat(Convert.ToString(compressed_indexes[x], 2), 2));

                for (int i = 0; i < cIndex.Length; i++)
                {
                    string bits = key.Substring(cIndex[i], index_length[x]);
                    cIndex[i] = Convert.ToInt32(bits, 2);
                }
            }

            for (int i = 0; i < octal_index.Length; i++)
            {
                rtn[i] = (char)cIndex[int.Parse(octal_index[i].ToString())];
            }

            return new string(rtn);
        }
    }

