using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace FA.JustBlog.Core.Data
{
    class JustBlogInitializer : CreateDatabaseIfNotExists<JustBlogContext>
    {
        protected override void Seed(JustBlogContext context)
        {
            Category programing = new Category()
            {
                Name = "Programing",
                UrlSlug = "programming",
                Description = "C#, Sql Server, HTML/CSS, Javascript, JQuery, ASP.NET MVC",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Title = "Track Your Keyword Placement with Ranktrackify Track Your Keyword Placement with Ranktrackify",
                        ShortDescription = "I don't need to tell you how important search engine placement is. You either earn it with quality content, loads of SEO work, paying for placement, or all of the above. And even we you achieve best placement, you need to be wary of...",
                        PostContent = "After signing up for free, your first steps are creating \"teams\" for which you'd like to track a set of. I like the team concept -- if you run a medium to large org where a subset of people care about given categories, teams make sense. After creating a team, you specify the devices, search engines, and keywords you want tracked:",
                        UrlSlug = "Track-Your-Keyword-Placement-with-Ranktrackify-Track-Your-Keyword-Placement-with-Ranktrackify",
                        Published = true,
                        PostedOn = new DateTime(2020, 1, 10),
                        Modified = new DateTime(2020, 1, 10),
                        Tags = new List<Tag>()
                        {
                            new Tag()
                            {
                                Name = "developer",
                                UrlSlug = "developer",
                                Description = "developer, programmer, tester, ...",
                                Count = 1
                            },
                            new Tag()
                            {
                                Name = "Sql Server",
                                UrlSlug = "sql-server",
                                Description = "Microsoft SQL Server is a relational database management system developed by Microsoft. As a database server, it is a software product with the primary ...",
                                Count = 1
                            },
                            new Tag()
                            {
                                Name = "Ranktrackify",
                                UrlSlug = "ranktrackify",
                                Description = "After creating a team, you specify the devices, search engines, and keywords you want tracked ...",
                                Count = 2
                            }
                        }
                    },
                    new Post()
                    {
                        Title = "How to Play Retro Game ROMs on Windows",
                        ShortDescription = "ideo games are always a fun time, something we desperately need during our COVID lockdown. A few years back I shared how to play retro games on Mac, as well as how to patch games to play popular ROM hacks like...",
                        PostContent = "When presented with more options, like SNES, you will want to take some time to research the differences between them. For example, the \"higan Accuracy\" is much more resource intensive, while the snes9x is used by some popular streamers, and the bsnes 2014 Performance seems to make the games feel a bit faster. Regardless, there's a wealth of emulators available at just one click.",
                        UrlSlug = "How-to-Play-Retro-Game-ROMs-on-Windows",
                        Published = false,
                        PostedOn = new DateTime(2020, 1, 15),
                        Modified = new DateTime(2020, 2, 1),
                        Tags = new List<Tag>()
                        {
                            new Tag()
                            {
                                Name = "window",
                                UrlSlug = "window",
                                Description = "Microsoft, windows, windows 10, MS, ...",
                                Count = 1
                            },
                            new Tag()
                            {
                                Name = "Sql Server",
                                UrlSlug = "sql-server",
                                Description = "Microsoft SQL Server is a relational database management system developed by Microsoft. As a database server, it is a software product with the primary ...",
                                Count = 1
                            }
                        }
                    },
                    new Post()
                    {
                        Title = "How to Add Native Keyword Aliases to Babel",
                        ShortDescription = "Those of you who follow this blog know that not every blog post is an endorsement of a technique but simply a tutorial how to accomplish something. Sometimes the technique described is probably not something you should do. This is one of those blog posts....",
                        PostContent = "The Babel parser is an essential tool in the web stack these days. Babel helps us to use JavaScript patterns before they hit the browser (optional chaining) as well as JSX for React. This got me to thinking: how easy would it be to write a Babel extension to allow us to use keyword alias, like fn instead of function? Let's have a look!",
                        UrlSlug = "How-to-Add-Native-Keyword-Aliases-to-Babel",
                        Published = true,
                        PostedOn = new DateTime(2020, 2, 2),
                        Modified = new DateTime(2020, 2, 2),
                        Tags = new List<Tag>()
                        {
                            new Tag()
                            {
                                Name = "javascript",
                                UrlSlug = "javascript",
                                Description = "javascript, js, jquery, ...",
                                Count = 1
                            }
                        }
                    }
                }
            };

            Category english = new Category()
            {
                Name = "English",
                UrlSlug = "english",
                Description = "learning english, study language, learning english, ...",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Title = "Choose your level to practise your listening",
                        ShortDescription = "Here you can find activities to practise your listening skills. Listening will help you to improve your understanding of the language and your pronunciation...",
                        PostContent = "The self-study lessons in this section are written and organised according to the levels of the Common European Framework of Reference for languages (CEFR). There are recordings of different situations and interactive exercises that practise the listening skills you need to do well in your studies, to get ahead at work and to communicate in English in your free time. The speakers you will hear are of different nationalities and the recordings are designed to show how English is being used in the world today.",
                        UrlSlug = "Choose-your-level-to-practise-your-listening",
                        Published = false,
                        PostedOn = new DateTime(2020, 1, 5),
                        Modified = new DateTime(2020, 1, 10),
                        Tags = new List<Tag>()
                        {
                            new Tag()
                            {
                                Name = "listening",
                                UrlSlug = "listening",
                                Description = "listening, skill, how to listening, ..",
                                Count = 1
                            }
                        }
                    },
                    new Post()
                    {
                        Title = "Choose your level to practise your reading",
                        ShortDescription = "There are different types of texts and interactive exercises that practise the reading skills you need to do well in your studies, to get ahead at work and to communicate in English in your free time...",
                        PostContent = "Take our free online English test to find out which level to choose. Select your level, from beginner (CEFR level A1) to advanced (CEFR level C1), and improve your reading skills at your own speed, whenever it's convenient for you.",
                        UrlSlug = "Choose-your-level-to-practise-your-reading",
                        Published = true,
                        PostedOn = new DateTime(2020, 3, 2),
                        Modified = new DateTime(2020, 3, 21),
                        Tags = new List<Tag>()
                        {
                            new Tag()
                            {
                                Name = "reading",
                                UrlSlug = "reading",
                                Description = "reading, skill, how to read, ..",
                                Count = 2
                            }
                        }
                    },
                }
            };

            context.Categories.Add(programing);
            context.Categories.Add(english);

            base.Seed(context);
        }
    }
}
