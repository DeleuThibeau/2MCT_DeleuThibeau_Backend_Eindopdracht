using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EindopdrachtBackEnd.Configuration;
using EindopdrachtBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EindopdrachtBackEnd.Data
{
    public interface IAnimeContext
    {
        DbSet<Anime> Animes { get; set; }
        DbSet<StreamingService> StreamingServices { get; set; }
        DbSet<AnimeStreamingService> AnimeStreamingServices { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Device> Devices { get; set; }
        DbSet<Studio> Studios { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class AnimeContext : DbContext, IAnimeContext
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<StreamingService> StreamingServices { get; set; }
        public DbSet<AnimeStreamingService> AnimeStreamingServices { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Studio> Studios { get; set; }

        private ConnectionStrings _connectionstrings;

        public AnimeContext(DbContextOptions<AnimeContext> options, IOptions<ConnectionStrings> connectionstrings) : base(options)
        {
            _connectionstrings = connectionstrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            options.UseSqlServer(_connectionstrings.SQL);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeStreamingService>()
                   .HasKey(cs => new { cs.AnimeId, cs.StreamingServiceId });

            modelBuilder.Entity<Device>().HasData(new Device() { DeviceId = 1, Name = "PC" });
            modelBuilder.Entity<Device>().HasData(new Device() { DeviceId = 2, Name = "TV" });

            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 1, Name = "Action", Description = "An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.). Action and adventure are usually categorized together (sometimes even as 'action-adventure') because they have much in common, and many stories fall under both genres simultaneously (for instance, the James Bond series can be classified as both)." });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 2, Name = "Drama", Description = "Drama is a mode of fictional representation through dialogue and performance. It is one of the literary genres, which is an imitation of some action. Drama is also a type of a play written for theater, television, radio, and film." });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 3, Name = "Comedy", Description = "Comedy is a story that tells about a series of funny, or comical events, intended to make the audience laugh. It is a very open genre, and thus crosses over with many other genres on a frequent basics." });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 4, Name = "Romance", Description = "Most often, however, a romance is understood to be 'love stories', emotion-driven stories that are primarily focused on the relationship between the main characters of the story. Beyond the focus on the relationship, the biggest defining characteristic of the romance genre is that a happy ending is always guaranteed,[10][11] perhaps marriage and living 'happily ever after,' or simply that the reader sees hope for the future of the romantic relationship" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 5, Name = "Fantasy", Description = "A fantasy story is about magic or supernatural forces, as opposed to technology as seen in science fiction. Depending on the extent of these other elements, the story may or may not be considered to be a 'hybrid genre' series; for instance, even though the Harry Potter series canon includes the requirement of a particular gene to be a wizard, it is referred to only as a fantasy series." });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 6, Name = "Psychological", Description = "In literature, psychological fiction (also psychological realism) is a narrative genre that emphasizes interior characterization and motivation to explore the spiritual, emotional, and mental lives of the characters." });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 7, Name = "Thriller", Description = "A thriller is a story that is usually a mix of fear and excitement. It has traits from the suspense genre and often from the action, adventure or mystery genres, but the level of terror makes it borderline horror fiction at times as well. It generally has a dark or serious theme, which also makes it similar to drama." });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 8, Name = "Horror", Description = "A horror story is told to deliberately scare or frighten the audience, through suspense, violence or shock. H. P. Lovecraft distinguishes two primary varieties in the 'Introduction' to Supernatural Horror in Literature: 1. Physical Fear or the 'mundanely gruesome' and 2. the true Supernatural Horror story or the 'Weird Tale.' The supernatural variety is occasionally called 'dark fantas',' since the laws of nature must be violated in some way, thus qualifying the story as 'fantastic.'" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 9, Name = "Slice of life", Description = "As the name says, watch a slice of someone's life  (it's wholesome, trust me) " });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 10, Name = "Sci-fi", Description = "Science fiction (once known as scientific romance) is similar to fantasy, except stories in this genre use scientific understanding to explain the universe that it takes place in. It generally includes or is centered on the presumed effects or ramifications of computers or machines; travel through space, time or alternate universes; alien life-forms; genetic engineering; or other such things. The science or technology used may or may not be very thoroughly elaborated on." });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 11, Name = "Mecha", Description = "A lot of robots GUUUUUUUUUUNDAAAAAAAAAAAM" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 12, Name = "Isekai", Description = "A new world with new adventures, LETS GOOOO!" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 13, Name = "Shounen", Description = "Watch a young man grow to a hero!" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 14, Name = "Seinen", Description = "Watch a full grown person handle the difficulties in life" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { GenreId = 15, Name = "Hentai", Description = "For the more cultured/adult viewers among us (If you know what I mean ;-) )" });

            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 1, Name = "Madhouse" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 2, Name = "Bones" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 3, Name = "Wit" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 4, Name = "Ufotable" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 5, Name = "Mappa" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 6, Name = "A-1 Pictures" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 7, Name = "Studio Sunrise" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 8, Name = "Production I.G" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 9, Name = "Studio Pierrot" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 10, Name = "Toei Animation" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 11, Name = "J.C Staff" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 12, Name = "Trigger" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 13, Name = "P.A. Works" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 14, Name = "Shaft" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 15, Name = "Brian's Base" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 16, Name = "Kyoto animation" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 17, Name = "Studio Deen" });
            modelBuilder.Entity<Studio>().HasData(new Studio() { StudioId = 18, Name = "white fox" });

            modelBuilder.Entity<StreamingService>().HasData(new StreamingService() { StreamingServiceId = 1, Name = "Netflix", IsLegal = true });
            modelBuilder.Entity<StreamingService>().HasData(new StreamingService() { StreamingServiceId = 2, Name = "Amazon", IsLegal = true });
            modelBuilder.Entity<StreamingService>().HasData(new StreamingService() { StreamingServiceId = 3, Name = "Crunchyroll", IsLegal = true });
            modelBuilder.Entity<StreamingService>().HasData(new StreamingService() { StreamingServiceId = 4, Name = "Funimation", IsLegal = true });
            modelBuilder.Entity<StreamingService>().HasData(new StreamingService() { StreamingServiceId = 5, Name = "Hulu", IsLegal = true });
            modelBuilder.Entity<StreamingService>().HasData(new StreamingService() { StreamingServiceId = 6, Name = "KissAnime", IsLegal = false });
            modelBuilder.Entity<StreamingService>().HasData(new StreamingService() { StreamingServiceId = 7, Name = "GogoAnime", IsLegal = false });

            modelBuilder.Entity<Anime>().Property(v => v.AnimeId).HasDefaultValue(Guid.NewGuid());

        }
    }
}
