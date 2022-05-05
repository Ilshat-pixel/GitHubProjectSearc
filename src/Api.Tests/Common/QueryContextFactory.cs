using System;
using GitHubProjectSearcher.Persistence;
using Microsoft.EntityFrameworkCore;
using GitHubProjectSearcher.Domain;
using System.Collections.Generic;

namespace Api.Tests.Common
{
    public class QueryContextFactory
    {

        public static int QueryIdForDelete = 5;


        public static ProjectDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ProjectDbContext(options);
            context.Database.EnsureCreated();
            context.Queries.AddRange(
                new GitHubProjectSearcher.Domain.Query
                {
                    QueryId =1,
                    SearchString="1",
                    Cards = new List<Card> {
                    new Card
                    {
                        CardId=1,
                        Name="1",
                        OwnerId=1,
                        StargazersCount=1,
                        Watchers =1,
                        ProjectLink="1",
                        Owner=new Owner
                        {
                            Login="1",
                            OwnerId=1
                        }
                    }
                    }
                },
                new GitHubProjectSearcher.Domain.Query
                {
                    QueryId = 2,
                    SearchString = "2",
                    Cards = new List<Card> {
                    new Card
                    {
                        CardId=2,
                        Name="2",
                        OwnerId=2,
                        StargazersCount=2,
                        Watchers =2,
                        ProjectLink="2",
                        Owner=new Owner
                        {
                            Login="2",
                            OwnerId=2
                        }
                    }
                    }
                },
                new GitHubProjectSearcher.Domain.Query
                {
                    QueryId = 3,
                    SearchString = "3",
                    Cards = new List<Card> {
                    new Card
                    {
                        CardId=3,
                        Name="3",
                        OwnerId=3,
                        StargazersCount=3,
                        Watchers =3,
                        ProjectLink="3",
                        Owner=new Owner
                        {
                            Login="3",
                            OwnerId=3
                        }
                    }
                    }
                },
                new GitHubProjectSearcher.Domain.Query
                {
                    QueryId = 4,
                    SearchString = "4",
                    Cards = new List<Card> {
                    new Card
                    {
                        CardId=4,
                        Name="4",
                        OwnerId=4,
                        StargazersCount=4,
                        Watchers =4,
                        ProjectLink="4",
                        Owner=new Owner
                        {
                            Login="4",
                            OwnerId=4
                        }
                    }
                    }
                },
                new GitHubProjectSearcher.Domain.Query
                {
                    QueryId = 5,
                    SearchString = "5",
                    Cards = new List<Card> {
                    new Card
                    {
                        CardId=5,
                        Name="5",
                        OwnerId=5,
                        StargazersCount=5,
                        Watchers =5,
                        ProjectLink="5",
                        Owner=new Owner
                        {
                            Login="5",
                            OwnerId=5
                        }
                    }
                    }
                }

            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(ProjectDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
