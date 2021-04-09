﻿// <auto-generated />
using System;
using EindopdrachtBackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EindopdrachtBackEnd.Migrations
{
    [DbContext(typeof(AnimeContext))]
    partial class AnimeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EindopdrachtBackEnd.Models.Anime", b =>
                {
                    b.Property<Guid>("AnimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("b27b8b13-7b2f-4333-9d2f-d9927df25c4a"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("StudioId")
                        .HasColumnType("int");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimeId");

                    b.HasIndex("GenreId");

                    b.HasIndex("StudioId");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("EindopdrachtBackEnd.Models.AnimeStreamingService", b =>
                {
                    b.Property<Guid>("AnimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StreamingServiceId")
                        .HasColumnType("int");

                    b.HasKey("AnimeId", "StreamingServiceId");

                    b.HasIndex("StreamingServiceId");

                    b.ToTable("AnimeStreamingServices");
                });

            modelBuilder.Entity("EindopdrachtBackEnd.Models.Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeviceId");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            DeviceId = 1,
                            Name = "PC"
                        },
                        new
                        {
                            DeviceId = 2,
                            Name = "TV"
                        });
                });

            modelBuilder.Entity("EindopdrachtBackEnd.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Description = "An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.). Action and adventure are usually categorized together (sometimes even as 'action-adventure') because they have much in common, and many stories fall under both genres simultaneously (for instance, the James Bond series can be classified as both).",
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = 2,
                            Description = "Drama is a mode of fictional representation through dialogue and performance. It is one of the literary genres, which is an imitation of some action. Drama is also a type of a play written for theater, television, radio, and film.",
                            Name = "Drama"
                        },
                        new
                        {
                            GenreId = 3,
                            Description = "Comedy is a story that tells about a series of funny, or comical events, intended to make the audience laugh. It is a very open genre, and thus crosses over with many other genres on a frequent basics.",
                            Name = "Comedy"
                        },
                        new
                        {
                            GenreId = 4,
                            Description = "Most often, however, a romance is understood to be 'love stories', emotion-driven stories that are primarily focused on the relationship between the main characters of the story. Beyond the focus on the relationship, the biggest defining characteristic of the romance genre is that a happy ending is always guaranteed,[10][11] perhaps marriage and living 'happily ever after,' or simply that the reader sees hope for the future of the romantic relationship",
                            Name = "Romance"
                        },
                        new
                        {
                            GenreId = 5,
                            Description = "A fantasy story is about magic or supernatural forces, as opposed to technology as seen in science fiction. Depending on the extent of these other elements, the story may or may not be considered to be a 'hybrid genre' series; for instance, even though the Harry Potter series canon includes the requirement of a particular gene to be a wizard, it is referred to only as a fantasy series.",
                            Name = "Fantasy"
                        },
                        new
                        {
                            GenreId = 6,
                            Description = "In literature, psychological fiction (also psychological realism) is a narrative genre that emphasizes interior characterization and motivation to explore the spiritual, emotional, and mental lives of the characters.",
                            Name = "Psychological"
                        },
                        new
                        {
                            GenreId = 7,
                            Description = "A thriller is a story that is usually a mix of fear and excitement. It has traits from the suspense genre and often from the action, adventure or mystery genres, but the level of terror makes it borderline horror fiction at times as well. It generally has a dark or serious theme, which also makes it similar to drama.",
                            Name = "Thriller"
                        },
                        new
                        {
                            GenreId = 8,
                            Description = "A horror story is told to deliberately scare or frighten the audience, through suspense, violence or shock. H. P. Lovecraft distinguishes two primary varieties in the 'Introduction' to Supernatural Horror in Literature: 1. Physical Fear or the 'mundanely gruesome' and 2. the true Supernatural Horror story or the 'Weird Tale.' The supernatural variety is occasionally called 'dark fantas',' since the laws of nature must be violated in some way, thus qualifying the story as 'fantastic.'",
                            Name = "Horror"
                        },
                        new
                        {
                            GenreId = 9,
                            Description = "As the name says, watch a slice of someone's life  (it's wholesome, trust me) ",
                            Name = "Slice of life"
                        },
                        new
                        {
                            GenreId = 10,
                            Description = "Science fiction (once known as scientific romance) is similar to fantasy, except stories in this genre use scientific understanding to explain the universe that it takes place in. It generally includes or is centered on the presumed effects or ramifications of computers or machines; travel through space, time or alternate universes; alien life-forms; genetic engineering; or other such things. The science or technology used may or may not be very thoroughly elaborated on.",
                            Name = "Sci-fi"
                        },
                        new
                        {
                            GenreId = 11,
                            Description = "A lot of robots GUUUUUUUUUUNDAAAAAAAAAAAM",
                            Name = "Mecha"
                        },
                        new
                        {
                            GenreId = 12,
                            Description = "A new world with new adventures, LETS GOOOO!",
                            Name = "Isekai"
                        },
                        new
                        {
                            GenreId = 13,
                            Description = "Watch a young man grow to a hero!",
                            Name = "Shounen"
                        },
                        new
                        {
                            GenreId = 14,
                            Description = "Watch a full grown person handle the difficulties in life",
                            Name = "Seinen"
                        },
                        new
                        {
                            GenreId = 15,
                            Description = "For the more cultured/adult viewers among us (If you know what I mean ;-) )",
                            Name = "Hentai"
                        });
                });

            modelBuilder.Entity("EindopdrachtBackEnd.Models.StreamingService", b =>
                {
                    b.Property<int>("StreamingServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeviceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLegal")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StreamingServiceId");

                    b.HasIndex("DeviceId");

                    b.ToTable("StreamingServices");

                    b.HasData(
                        new
                        {
                            StreamingServiceId = 1,
                            IsLegal = true,
                            Name = "Netflix"
                        },
                        new
                        {
                            StreamingServiceId = 2,
                            IsLegal = true,
                            Name = "Amazon"
                        },
                        new
                        {
                            StreamingServiceId = 3,
                            IsLegal = true,
                            Name = "Crunchyroll"
                        },
                        new
                        {
                            StreamingServiceId = 4,
                            IsLegal = true,
                            Name = "Funimation"
                        },
                        new
                        {
                            StreamingServiceId = 5,
                            IsLegal = true,
                            Name = "Hulu"
                        },
                        new
                        {
                            StreamingServiceId = 6,
                            IsLegal = false,
                            Name = "KissAnime"
                        },
                        new
                        {
                            StreamingServiceId = 7,
                            IsLegal = false,
                            Name = "GogoAnime"
                        });
                });

            modelBuilder.Entity("EindopdrachtBackEnd.Models.Studio", b =>
                {
                    b.Property<int>("StudioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudioId");

                    b.ToTable("Studios");

                    b.HasData(
                        new
                        {
                            StudioId = 1,
                            Name = "Madhouse"
                        },
                        new
                        {
                            StudioId = 2,
                            Name = "Bones"
                        },
                        new
                        {
                            StudioId = 3,
                            Name = "Wit"
                        },
                        new
                        {
                            StudioId = 4,
                            Name = "Ufotable"
                        },
                        new
                        {
                            StudioId = 5,
                            Name = "Mappa"
                        },
                        new
                        {
                            StudioId = 6,
                            Name = "A-1 Pictures"
                        },
                        new
                        {
                            StudioId = 7,
                            Name = "Studio Sunrise"
                        },
                        new
                        {
                            StudioId = 8,
                            Name = "Production I.G"
                        },
                        new
                        {
                            StudioId = 9,
                            Name = "Studio Pierrot"
                        },
                        new
                        {
                            StudioId = 10,
                            Name = "Toei Animation"
                        },
                        new
                        {
                            StudioId = 11,
                            Name = "J.C Staff"
                        },
                        new
                        {
                            StudioId = 12,
                            Name = "Trigger"
                        },
                        new
                        {
                            StudioId = 13,
                            Name = "P.A. Works"
                        },
                        new
                        {
                            StudioId = 14,
                            Name = "Shaft"
                        },
                        new
                        {
                            StudioId = 15,
                            Name = "Brian's Base"
                        },
                        new
                        {
                            StudioId = 16,
                            Name = "Kyoto animation"
                        },
                        new
                        {
                            StudioId = 17,
                            Name = "Studio Deen"
                        },
                        new
                        {
                            StudioId = 18,
                            Name = "white fox"
                        });
                });

            modelBuilder.Entity("EindopdrachtBackEnd.Models.Anime", b =>
                {
                    b.HasOne("EindopdrachtBackEnd.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EindopdrachtBackEnd.Models.Studio", "Studio")
                        .WithMany()
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("EindopdrachtBackEnd.Models.AnimeStreamingService", b =>
                {
                    b.HasOne("EindopdrachtBackEnd.Models.Anime", null)
                        .WithMany("AnimeStreamingServices")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EindopdrachtBackEnd.Models.StreamingService", "StreamingService")
                        .WithMany()
                        .HasForeignKey("StreamingServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StreamingService");
                });

            modelBuilder.Entity("EindopdrachtBackEnd.Models.StreamingService", b =>
                {
                    b.HasOne("EindopdrachtBackEnd.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("EindopdrachtBackEnd.Models.Anime", b =>
                {
                    b.Navigation("AnimeStreamingServices");
                });
#pragma warning restore 612, 618
        }
    }
}
