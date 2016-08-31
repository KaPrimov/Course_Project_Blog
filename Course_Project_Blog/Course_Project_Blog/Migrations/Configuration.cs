

using System.Runtime.InteropServices;
using Microsoft.ApplicationInsights.Web;

namespace Course_Project_Blog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                // If the database is empty, populate sample data in it

                CreateUser(context, "admin@gmail.com", "123456", "System Administrator");
                CreateUser(context, "pesho@gmail.com", "123456", "Peter Ivanov");
                CreateUser(context, "merry@gmail.com", "123456", "Maria Petrova");
                CreateUser(context, "geshu@gmail.com", "123456", "George Petrov");

                CreateRole(context, "Administrators");
                AddUserToRole(context, "admin@gmail.com", "Administrators");
                CreateRole(context, "Moderators");
                AddUserToRole(context, "pesho@gmail.com", "Moderators");

                CreatePost(context,
                    title: "Possible Mourinho signings ?",
                    body:
                        @"<p>I was talking to someone about Morgan on here earlier in the week and I think the arrival of Paul could be the making of him, because it will simplify his game and focus his roll. I'm sure we'll see more out of Morgan this season; the bits and pieces we've seen of him in pre-season, he looks far more aggressive in his hunting down of the ball. 'See ball, win ball, pass ball,' should be his mantra this season</p>",
                    date: new DateTime(2016, 03, 27, 17, 53, 48),
                    authorUsername: "merry@gmail.com"
                    );

                CreatePost(context,
                    title: "Enough of Blaming Van Gaal",
                    body:
                        @"<p>I think people was blinded by Moyes getting everyone to underperform. When SAF left most would say it was a good squad, but with holes like central midfield and could need top quality up front as well. 
                        The likes of De Gea, Smalling, Valencia, Young and Carrick who was among the best performers under LVGs time and even Fellaini saved us a bit. Moyes and LVG really *** it up. Shaw was a very good signing and Herrera decent, but many say they were not his signings. I don't think he did that good of a job, but Rashford has changed quite a bit of the tone for sure. Now we have got in a lot of quality as well this summer. Martial we payed huge sum of money and he may be very good and is an improvement, but he still has a lot to prove and started this season poor. 
                        I have faith in him coming very strong, but paying so much money as LVG has done you can't say he did a very good job. What LVG did though was lower expectations and now we can really push up with Zlatan and Mourinho two winners leading us hopefully.</p>",
                    date: new DateTime(2016, 05, 11, 08, 22, 03),
                    authorUsername: "merry@gmail.com"
                    );

                CreatePost(context,
                    title: "Man Utd vs Bournemouth - Your line-ups?",
                    body:
                        @"<p>I will put up 2 line ups, one I prefer and 2 the one I think will run out on Sunday. The preferred one also represents what I consider my best 11. 1) De Gea 2) Fonsu-Mensah 3) Shaw 4) Rojo ( until Smalling is back or Fonsu Mensa is given a chance there) 5) Bailly 6) Blind ( of all DMs we have the most creative) 7) Depay 8) Pogba ( might be to early for him) 9) Zlatan ( can`t believe people would want him subbed already after 1 semi-friendly, afterall he did his job) 10) Mikhytarin 11) Martial Unfortunately very small chance of the above happening, so the team I expect to run out is; 1) De Gea 2) Valencia ( not bad) 3) Shaw ( the real deal) 4) Blind ( I prefer him at 6 but will have to do till Smalling is ready or Fonsu is tried there) 5) Bailly ( the real feal) 6) Carrick ( I prefer Schenderlin) 7) Lingard (not bad but I feel they are about 3 or 4 guyz better than him for that position) 8) Herrera ( am hoping Mou would have seen Fellaini is devoid of any creativity) 9) Zlatan ( come on guyz-one game) 10) Rooney ( sigh-sigh-sigh) 11) Martial ( straightforward for now.Needs to up it a bit though) That`s about it then.</p>",
                    date: new DateTime(2016, 03, 27, 17, 53, 48),
                    authorUsername: "merry@gmail.com"
                    );

                CreatePost(context,
                    title: "Ed Woodward take a bow.",
                    body:
                        @"Yeah hats off. Ed earned his cheese this summer. One hell of job landing all 4 targets.
                        The best player in the Bundesliga for a very modest price. Zlatan is one hell of a coup. Bailly looks twice the player than Stones, for nearly half the price. And then landing the most desirable target in the world.",
                    date: new DateTime(2016, 02, 18, 22, 14, 38),
                    authorUsername: "pesho@gmail.com"
                    );

                CreatePost(context,
                    title: "Lets sign Antoine Griezmann next summer",
                    body:
                        @"Just to be a little mischievous and throw a name out there 😈 Dybala. I do think that next year the position Rooney plays is going to have a question mark over it. I'd love Griezman, think he'd be great for it. If Rooney has an OK season then Jose might hold on the decision and see what happens.
                        Dybala can play in the same position and for me is more creative so I think he would be an option but if he has a season similar to his last then Juventus are going to ask for more than Pogba and surely Barca are eyeing him as Messi's successor.</p>",
                    date: new DateTime(2016, 04, 11, 19, 02, 05),
                    authorUsername: "geshu@gmail.com"
                    );

                CreatePost(context,
                    title: "DONE DEAL #POGBACK",
                    body:
                        @"If Paul is worth 90 million, then God knows what the next Paul Scholes would go for... but if he's out there, lets hope we get him.
                        We have been desperate for a driving force from the middle of the park for years, so if Paul can mature into that for us, then we will become a formidable side. Watching him playing for France in the summer, it looked the lad was playing with the handbrake on; it's Jose' job now to release the lad and allow him to play his natural game. I'm looking forward to watching Paul develop over the next 2 or 3 years, in to potentially, a world class player; and we all know we've been short on those for a while.”</p>",
                    date: new DateTime(2016, 06, 30, 17, 36, 52),
                    authorUsername: "merry@gmail.com"
                    );
                CreateGames(context,
                    teams: "Hull - Man. Utd",
                    date: new DateTime(2016, 08, 27), 
                    time: new DateTime(2016, 08, 27, 14, 30 , 00), 
                    result: "0 - 1",
                    authorUsername: "admin@gmail.com"
                    );
                CreateGames(context,
                   teams: "Man. Utd - Southampton",
                   date: new DateTime(2016, 08, 19),
                   time: new DateTime(2016, 08, 19, 17, 30, 00),
                   result: "2 - 0",
                   authorUsername: "admin@gmail.com"
                   );
                CreateGames(context,
                   teams: "Man. Utd - Man. City",
                   date: new DateTime(2016, 10, 09),
                   time: new DateTime(2016, 10, 09, 14, 30, 00),
                   result: "Will be played",
                   authorUsername: "admin@gmail.com"
                   );

                context.SaveChanges();
            }
        }

        private void CreateUser(ApplicationDbContext context,
             string email, string password, string fullName)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullName
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreateRole(ApplicationDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void CreatePost(ApplicationDbContext context,
            string title, string body, DateTime date, string authorUsername)
        {
            var post = new Post();
            post.Title = title;
            post.Body = body;
            post.Date = date;
            post.Author = context.Users.Where(u => u.UserName == authorUsername).FirstOrDefault();
            context.Posts.Add(post);
        }

        private void CreateGames(ApplicationDbContext context, string teams, DateTime date, DateTime time, string result, string authorUsername)
        {
            var game = new Game();
            game.Teams = teams;
            game.Date = date;
            game.Time = time;
            game.Result = result;
            game.Author = context.Users.Where(u => u.UserName == authorUsername).FirstOrDefault();
            context.Games.Add(game);
        }

        
    }
}
