﻿using FO74EQ_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Repository.Database
{
    public class NeptunDbContext : DbContext
    {
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NagyA\source\repos\FO74EQ_HFT_2021222\FO74EQ_HFT_2021222.Repository\Database\Neptun.mdf;Integrated Security=True

        public NeptunDbContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<GradeBook> GradeBook { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Neptun.mdf;Integrated Security=True;MultipleActiveResultSets=true";

                builder
                   //.UseSqlServer(conn)
                   .UseLazyLoadingProxies()
                   .UseInMemoryDatabase("Neptun");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom>(cRoom => cRoom
                .HasMany(cRoom => cRoom.Courses)
                .WithOne(Course => Course.ClassRoom)
                .HasForeignKey(Course => Course.ClassRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull));
            // - DeleteBehavior.ClientSetNull: Csak olyanra engedi kiadni a törlést, amire nincs hivatkozás. Egyéb esetben, elszállna kivétellel.

            modelBuilder.Entity<Student>(stud => stud
                .HasMany(stud => stud.GradeBooks)
                .WithOne(grade => grade.Neptun)
                .HasForeignKey(grade => grade.NeptunId)
                .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<Teacher>(teacher => teacher
                .HasMany(teacher => teacher.GradeBooks)
                .WithOne(grade => grade.Teacher)
                .HasForeignKey(grade => grade.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<Course>(course => course
                .HasOne(course => course.Requirement)
                .WithMany(course => course.InverseRequirement)
                .HasForeignKey(course => course.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<Course>(course => course
                .HasMany(course => course.GradeBooks)
                .WithOne(grade => grade.Course)
                .HasForeignKey(grade => grade.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull));


            modelBuilder.Entity<ClassRoom>().HasData(new ClassRoom[]
            {
                new ClassRoom("1#22"),
                new ClassRoom("2#22"),
                new ClassRoom("3#22"),
                new ClassRoom("4#25"),
                new ClassRoom("5#25"),
                new ClassRoom("6#25"),
                new ClassRoom("7#25"),
                new ClassRoom("8#25"),
                new ClassRoom("9#25"),
                new ClassRoom("10#25"),
                new ClassRoom("11#25"),
                new ClassRoom("12#30"),
                new ClassRoom("13#30"),
                new ClassRoom("14#30"),
                new ClassRoom("15#30"),
                new ClassRoom("16#30"),
                new ClassRoom("17#35"),
                new ClassRoom("18#35"),
                new ClassRoom("19#40"),
                new ClassRoom("20#15"),
                new ClassRoom("21#20"),
                new ClassRoom("22#15"),
                new ClassRoom("23#20")
            });


            modelBuilder.Entity<Teacher>().HasData(new Teacher[]
            {
                new Teacher("373#John#Bass#212651"),
                new Teacher("374#Armando#Slater#162134"),
                new Teacher("375#Rhiannon#Pennington#265365"),
                new Teacher("376#Abigail#Thomas#392938"),
                new Teacher("377#Nora#Pennington#151121"),
                new Teacher("378#John#Vang#364022"),
                new Teacher("379#Porter#Hooper#232403"),
                new Teacher("380#Ocean#Leonard#322022"),
                new Teacher("381#Iliana#Mathews#308665"),
                new Teacher("382#Natalie#Mccarty#312991"),
                new Teacher("383#Kelly#Bentley#366342"),
                new Teacher("384#Eliana#Thompson#355073"),
                new Teacher("385#John#Mitchell#311003"),
                new Teacher("386#Kai#Riley#355682"),
                new Teacher("387#Noelani#Cochran#235839"),
                new Teacher("388#Emma#Bowers#290193"),
                new Teacher("389#Allistair#Randolph#353792"),
                new Teacher("390#John#Gibbs#203080"),
                new Teacher("391#Blythe#Black#219409"),
                new Teacher("392#Leonard#Griffin#362017"),
                new Teacher("393#Trevor#Hooper#333835"),
                new Teacher("394#Alan#Fuentes#353610"),
                new Teacher("395#Margaret#Mueller#206558"),
                new Teacher("396#Jelani#Petersen#346723"),
                new Teacher("397#Selma#Neal#349540"),
                new Teacher("398#Jenette#Jackson#351939"),
                new Teacher("399#Keefe#Bauer#354312"),
                new Teacher("400#Erica#Long#170731"),
                new Teacher("401#Uma#Alexander#168082"),
                new Teacher("402#James#York#291997"),
                new Teacher("403#Jordan#Harmon#295823"),
                new Teacher("404#Ocean#Potts#265343"),
                new Teacher("405#Jackson#Vega#317577"),
                new Teacher("406#Calvin#Patrick#321064"),
                new Teacher("407#Kelly#Kerr#267875"),
                new Teacher("408#Megan#Nieves#242917"),
                new Teacher("409#Maggie#Vaughan#254022"),
                new Teacher("410#Chancellor#Riley#178904"),
                new Teacher("411#Ian#Booker#345914"),
                new Teacher("412#Tallulah#Ayala#362935"),
                new Teacher("413#Hilda#Rosario#310155"),
                new Teacher("414#Lynn#Mullen#274189"),
                new Teacher("415#Steven#Lawson#196795"),
                new Teacher("416#Akeem#Rowland#177451"),
                new Teacher("417#Bethany#Hooper#392432"),
                new Teacher("418#Quin#Black#362587"),
                new Teacher("419#Cassidy#Rose#268472"),
                new Teacher("420#Kimberley#Charles#208740"),
                new Teacher("421#Forrest#Anderson#298583"),
                new Teacher("422#Oliver#Harrison#166887"),
                new Teacher("423#Karyn#Silva#375179"),
                new Teacher("424#Jordan#Hale#160871"),
                new Teacher("425#John#Ware#244652"),
                new Teacher("426#Lacota#Barker#256375"),
                new Teacher("427#Oliver#Hicks#294022"),
                new Teacher("428#Raymond#Mullen#196586"),
                new Teacher("429#Odette#Hardy#366010"),
                new Teacher("430#Dacey#Ball#204700"),
                new Teacher("431#Jesse#Holloway#195303"),
                new Teacher("432#Owen#Barrett#376543"),
                new Teacher("433#Vielka#Levine#168588"),
                new Teacher("434#Dylan#Miles#312074"),
                new Teacher("435#Magee#Weiss#358962"),
                new Teacher("436#Steven#Huffman#200575"),
                new Teacher("437#Rooney#Black#195788"),
                new Teacher("438#Forrest#Heath#157722"),
                new Teacher("439#Jordan#Hubbard#153159"),
                new Teacher("440#Barbara#Walton#307135"),
                new Teacher("441#Bruce#Porter#380992"),
                new Teacher("442#Barbara#Dickerson#296150"),
                new Teacher("443#Lacy#Lynn#299455"),
                new Teacher("444#Logan#Faulkner#154499"),
                new Teacher("445#Barbara#Black#398153"),
                new Teacher("446#Holmes#Jefferson#230346"),
                new Teacher("447#Calista#Ball#399245"),
                new Teacher("448#Rashad#Greer#229492"),
                new Teacher("449#Alvin#Porter#331340"),
                new Teacher("450#Oliver#Hopper#171172"),
                new Teacher("451#Jonas#Mckee#339392"),
                new Teacher("452#Jerry#Goff#271729"),
                new Teacher("453#Barbara#Johnston#200922"),
                new Teacher("454#Mannix#Thomas#373923"),
                new Teacher("455#Brent#Collins#158024"),
                new Teacher("456#Tanner#Jarvis#263481"),
                new Teacher("457#Stacy#Terrell#325021"),
                new Teacher("458#Carson#Puckett#179473"),
                new Teacher("459#Ashton#Summers#295549"),
                new Teacher("460#Hasad#Dodson#158555"),
                new Teacher("461#Clarke#Gilbert#376511"),
                new Teacher("462#Leonard#Schmidt#241381"),
                new Teacher("463#Fritz#Mills#224798"),
                new Teacher("464#Aspen#Ramos#305729"),
                new Teacher("465#Mariko#Bradford#164821"),
                new Teacher("466#Maxwell#Morin#240500"),
                new Teacher("467#Kessie#Shaw#142513"),
                new Teacher("468#Myra#Warner#246500"),
                new Teacher("469#Owen#Poole#381119"),
                new Teacher("470#Herman#Ballard#196759"),
                new Teacher("471#Priscilla#Sanford#326383"),
                new Teacher("472#Malcolm#Vasquez#318605")
            });


            modelBuilder.Entity<Student>().HasData(new Student[]
            {
new Student("1#Ayala#Burton#2000*6*15#dui.lectus@ipsumac.ca"),
new Student("2#Merritt#Jelani#2000*1*9#Praesent.eu.nulla@sedconsequat.com"),
new Student("3#Delaney#Basil#1999*3*28#accumsan.interdum@seddui.edu"),
new Student("4#Glover#Emery#1998*11*30#diam.Pellentesque@molestie.ca"),
new Student("5#Hyde#Mona#1999*12*25#tellus.justo@Utnecurna.co.uk"),
new Student("6#Levine#Deacon#1999*1*3#luctus@Integer.co.uk"),
new Student("7#Hunt#Wynter#2000*2*7#rutrum.lorem@ametultricies.com"),
new Student("8#Velasquez#Theodore#1999*8*4#ipsum.dolor.sit@estNunclaoreet.org"),
new Student("9#Suarez#Brenna#1998*4*2#mauris.rhoncus@Sedcongue.edu"),
new Student("10#Murray#Adara#1998*9*20#dolor.Fusce@risusIn.org"),
new Student("11#Gaines#Finn#1999*2*24#Nam.consequat@idmagnaet.ca"),
new Student("12#Mason#Colt#1999*12*6#varius.Nam.porttitor@interdum.edu"),
new Student("13#Cardenas#Kadeem#1999*9*17#magna@tellusAeneanegestas.org"),
new Student("14#Rhodes#Sharon#2000*5*2#sem@ac.net"),
new Student("15#Adams#Cathleen#1999*4*13#ipsum.nunc@Nulla.co.uk"),
new Student("16#Zamora#Rebecca#2000*7*14#nec@consectetuermauris.edu"),
new Student("17#Garcia#Aretha#1999*11*20#a.facilisis.non@malesuadafamesac.co.uk"),
new Student("18#Hancock#Baxter#1998*5*22#enim.nisl@ullamcorper.net"),
new Student("19#Rivers#Ashton#1999*5*1#mollis@congueturpis.ca"),
new Student("20#Bryan#Rachel#2000*8*28#orci.lacus.vestibulum@blanditenim.edu"),
new Student("21#Foreman#Zeph#2000*3*15#venenatis.lacus.Etiam@ante.org"),
new Student("22#Watts#Vanna#1999*12*25#mi@utquamvel.com"),
new Student("23#Dean#Noah#1999*2*8#auctor.nunc.nulla@etpedeNunc.edu"),
new Student("24#Norman#Cedric#1999*12*21#imperdiet.ornare.In@tellus.edu"),
new Student("25#Richardson#Kameko#2000*8*20#Fusce@gravida.net"),
new Student("26#Deleon#Stephen#1999*2*12#Integer.sem@sit.com"),
new Student("27#Crane#Timothy#1998*5*27#vulputate@interdum.co.uk"),
new Student("28#Ayers#Peter#2000*5*26#velit@orci.org"),
new Student("29#Sears#Claudia#1999*3*30#Morbi@mifelis.edu"),
new Student("30#Melendez#Wing#1999*5*17#Suspendisse@risus.org"),
new Student("31#Albert#Ralph#1999*10*17#nulla@quis.com"),
new Student("32#Welch#Hashim#2000*1*13#tincidunt.dui.augue@nec.ca"),
new Student("33#Morgan#Vielka#1998*5*21#non.ante@sodalespurusin.co.uk"),
new Student("34#Larson#Dolan#1998*5*10#erat@necurna.edu"),
new Student("35#Wade#Adele#1999*7*21#ipsum.dolor@imperdiet.edu"),
new Student("36#Mccray#Suki#1999*7*27#dolor@diam.net"),
new Student("37#Gardner#David#1998*4*14#montes@pedesagittisaugue.org"),
new Student("38#Mcintosh#Jameson#1998*4*9#sagittis@eleifend.ca"),
new Student("39#Payne#Connor#1998*8*1#consectetuer.adipiscing.elit@egestasa.co.uk"),
new Student("40#Watts#Gabriel#1998*6*29#taciti.sociosqu.ad@malesuadaiderat.co.uk"),
new Student("41#Hale#Dean#1998*4*29#eros.Proin.ultrices@ametmassa.co.uk"),
new Student("42#Schneider#Quon#1999*8*25#aliquet@montes.ca"),
new Student("43#Kline#Jonah#1998*1*12#Integer.aliquam.adipiscing@sitametconsectetuer.ca"),
new Student("44#Haney#Macy#1999*6*26#non.nisi.Aenean@Nuncuterat.ca"),
new Student("45#Mosley#Willow#2000*4*7#Ut@elementumategestas.ca"),
new Student("46#Chambers#Ira#1999*7*16#dui.semper@Namacnulla.edu"),
new Student("47#Parsons#Hayley#2000*8*14#egestas.a@et.co.uk"),
new Student("48#Tanner#Jeanette#1998*1*21#blandit@egetmollis.net"),
new Student("49#Smith#Evangeline#1999*7*17#lacus@velnisl.edu"),
new Student("50#Wade#Geoffrey#1999*1*20#arcu.Nunc.mauris@PhasellusornareFusce.org"),
new Student("51#Albert#Adrian#2000*5*2#odio.auctor@tristiquenequevenenatis.com"),
new Student("52#Tyson#Uriah#1999*10*17#In@diam.org"),
new Student("53#Suarez#Liberty#1998*10*26#sem@arcuetpede.com"),
new Student("54#Vaughn#Dexter#2000*2*29#at.auctor.ullamcorper@euismodacfermentum.org"),
new Student("55#Larsen#Baker#1999*12*31#sed.orci@mi.co.uk"),
new Student("56#Henry#Nigel#1998*7*5#dui@elementumsemvitae.edu"),
new Student("57#Bradley#Marah#1999*10*11#non.enim.commodo@erat.org"),
new Student("58#Phillips#Kaseem#2000*9*9#luctus.sit.amet@Quisque.ca"),
new Student("59#Mullen#Reagan#1998*7*26#Nulla.facilisis@Donec.net"),
new Student("60#Wise#Davis#1998*12*10#pede.malesuada.vel@mattissemperdui.edu"),
new Student("61#Baker#Aladdin#1998*11*22#In.at@mauris.ca"),
new Student("62#Conrad#Ross#1998*2*16#Vivamus.sit.amet@eleifendnon.org"),
new Student("63#Case#Zorita#1999*6*29#neque@ametornare.com"),
new Student("64#Snider#Isaac#1999*3*10#tellus.Nunc.lectus@sed.net"),
new Student("65#Hinton#Miriam#1999*12*6#Fusce.dolor@Cumsociisnatoque.co.uk"),
new Student("66#Barry#Jason#1998*6*17#amet.ante.Vivamus@lectusNullamsuscipit.edu"),
new Student("67#Davis#Amethyst#2000*3*27#tellus.Phasellus@Nuncmauris.org"),
new Student("68#Marks#Russell#1998*9*4#erat@semvitae.org"),
new Student("69#Mcintosh#Debra#1999*11*20#gravida.molestie@egestasurna.co.uk"),
new Student("70#Vazquez#Xerxes#2000*5*31#at.fringilla@tortorat.co.uk"),
new Student("71#Barnes#Patricia#1999*12*25#Proin.mi@liberoProin.com"),
new Student("72#Levy#Ulla#1999*8*26#ante@diamPellentesque.edu"),
new Student("73#Roy#Dustin#2000*2*5#urna.Nunc@eget.org"),
new Student("74#Crosby#Reuben#1999*12*17#velit@ridiculus.com"),
new Student("75#Rivers#Lee#1999*9*4#nunc@porttitor.org"),
new Student("76#Beasley#Cadman#1999*10*3#aliquet@auctornon.ca"),
new Student("77#Buckley#Stone#1998*2*5#vulputate.lacus@utnisia.com"),
new Student("78#Vinson#Dante#2000*6*22#adipiscing.non@lorem.co.uk"),
new Student("79#Hodges#Sydnee#1999*2*9#Phasellus.dolor.elit@eratnonummyultricies.com"),
new Student("80#Mcpherson#Quentin#2000*3*17#Sed.eget@Etiamvestibulum.ca"),
new Student("81#Martinez#Ila#2000*7*18#pede.Nunc.sed@faucibus.co.uk"),
new Student("82#Fowler#Judith#1998*6*17#tincidunt.congue@ut.net"),
new Student("83#Fitzpatrick#Prescott#1999*6*24#eget@tincidunttempus.net"),
new Student("84#Hicks#Adam#1999*5*11#auctor@arcuvel.com"),
new Student("85#Dixon#Marsden#1998*2*18#tincidunt.nunc.ac@hendrerit.ca"),
new Student("86#Le#Abbot#1998*4*25#non@dapibus.org"),
new Student("87#Duncan#Candace#1998*1*10#pede.Nunc@interdumNuncsollicitudin.co.uk"),
new Student("88#Floyd#Rylee#2000*3*11#ac.fermentum.vel@quis.net"),
new Student("89#Avila#Grady#1998*2*3#Donec@ametrisus.edu"),
new Student("90#Bolton#Fletcher#1998*10*1#inceptos.hymenaeos@necenimNunc.edu"),
new Student("91#Roach#Lara#1998*4*30#urna.justo@metus.org"),
new Student("92#Watts#Roary#2000*2*22#tempor.erat.neque@lorem.org"),
new Student("93#Aguirre#Wynne#1999*7*7#porttitor.interdum.Sed@parturientmontes.co.uk"),
new Student("94#Graham#Stewart#1999*2*17#Quisque@Nuncpulvinararcu.com"),
new Student("95#Dennis#Eden#2000*5*11#faucibus@sapien.net"),
new Student("96#Mccall#Moses#2000*8*19#Donec@elitEtiamlaoreet.ca"),
new Student("97#Stokes#Colin#1999*5*26#justo.nec@Morbiaccumsan.com"),
new Student("98#Jenkins#Paula#1998*9*1#arcu.Curabitur.ut@ascelerisque.ca"),
new Student("99#Fowler#Giselle#1998*2*6#metus@enimmitempor.com"),
new Student("100#Melton#Marah#1999*5*16#sit@semperduilectus.edu"),            });


            modelBuilder.Entity<Course>().HasData(new Course[]
            {
                new Course("1#Animal Science#07*30*2019#11#16#0"),
                new Course("2#Pottery#08*02*2018#5#6#1"),
                new Course("3#Choir#04*10*2019#8#9#2"),
                new Course("4#Rock Climbing#02*10*2018#1#14#3"),
                new Course("5#Meteorology#07*05*2019#6#4#2"),
                new Course("6#Digital Arts#02*14*2018#11#1#1"),
                new Course("7#Team Sports#05*30*2018#10#11#3"),
                new Course("8#Grammar#11*01*2018#12#17#3"),
                new Course("9#Organic Chemistry#08*31*2018#1#11#4"),
                new Course("10#Study#03*02*2019#11#5#1"),
                new Course("11#Consumer Math#12*29*2018#11#20#1"),
                new Course("12#Fundamental Math or Basic Math#01*29*2018#10#4#4"),
                new Course("13#Algebra#09*01*2019#11#10#5"),
                new Course("14#Music History#05*20*2018#8#7#1"),
                new Course("15#Skills#07*14*2018#2#23#1"),
                new Course("16#Civics#09*21*2018#12#16#4"),
                new Course("17#Ecology#05*15*2018#3#16#5"),
                new Course("18#Earth Science#09*24*2018#8#20#12"),
                new Course("19#Honors Courses in any core subject#03*30*2018#13#18#18"),
                new Course("20#Physical Science#12*09*2017#13#15#19"),
                new Course("21#Weightlifting#06*27*2019#5#1#9"),
                new Course("22#Physical Fitness#10*17*2017#8#2#7"),
                new Course("23#Gardening#02*17*2018#8#7#10"),
                new Course("24#Child Development#04*06*2019#3#16#23"),
                new Course("25#Political Science#05*06*2018#3#7#17"),
                new Course("26#Oceanography#07*02*2018#7#20#18"),
                new Course("27#Personal Organization#04*22*2019#1#6#17"),
                new Course("28#Outdoor Survival Skills#11*21*2018#6#17#7"),
                new Course("29#Oceanography#06*01*2019#8#15#23"),
                new Course("30#Gardening#06*23*2019#9#23#3"),
                new Course("31#World Religions#07*06*2019#10#1#27"),
                new Course("32#Geometry#01*08*2018#8#6#21"),
                new Course("33#Driver’s Education#08*11*2019#9#8#17"),
                new Course("34#Team Sports#06*24*2018#14#7#11"),
                new Course("35#Social Skills#09*30*2018#6#8#20"),
                new Course("36#Ancient History#07*17*2019#9#13#28"),
                new Course("37#Heroes, Myth and Legend#01*04*2018#13#12#22"),
                new Course("38#Film as Literature#09*19*2018#8#21#21"),
                new Course("39#Genealogy#05*31*2018#14#19#6"),
                new Course("40#Ecology#10*20*2018#8#19#27"),
                new Course("41#Consumer Math#06*19*2018#15#14#11"),
                new Course("42#Personal Finance and Investing#05*20*2019#9#12#16"),
                new Course("43#Philosophy#02*01*2019#9#11#25"),
                new Course("44#Classical Music Studies#05*25*2018#14#9#41"),
                new Course("45#Computer Repair#10*09*2018#3#12#13"),
                new Course("46#Art I#11*05*2018#13#9#22"),
                new Course("47#Art II#03*14*2019#12#8#38"),
                new Course("48#Consumer Math#12*08*2018#6#12#20"),
                new Course("49#Choir#08*18*2018#3#9#25"),
                new Course("50#Yearbook#08*30*2019#6#22#25"),
                new Course("51#Social Skills#07*23*2019#3#23#42"),
                new Course("52#Art III#12*28*2018#10#12#47"),
                new Course("53#Grammar#11*23*2018#4#8#52"),
                new Course("54#Gymnastics#02*15*2018#4#12#22"),
                new Course("55#Archery#10*27*2017#10#6#32"),
                new Course("56#Meteorology#05*20*2018#14#15#17"),
                new Course("57#LOGIC#01*19*2018#8#1#52"),
                new Course("58#Drafting#03*07*2019#6#3#41"),
                new Course("59#Introduction to Algebra#03*26*2018#1#11#56"),
                new Course("60#Small Engine Mechanics#12*23*2017#2#16#56"),
                new Course("61#World Religions#01*15*2019#9#9#53"),
                new Course("62#Sociology#08*01*2019#5#13#39"),
                new Course("63#Adapted P.E#10*18*2018#10#21#28"),
                new Course("64#Meteorology#02*01*2018#8#17#33"),
                new Course("65#Creative Writing#10*11*2017#11#9#17"),
                new Course("66#US History#06*25*2018#8#17#25"),
                new Course("67#Lifeskills#11*29*2017#4#13#26"),
                new Course("68#Oceanography#01*27*2018#11#17#13"),
                new Course("69#Desktop Publishing#01*19*2018#7#23#43"),
                new Course("70#Track and Field#05*21*2019#1#20#26"),
                new Course("71#Ancient Literature#01*15*2018#14#14#57"),
                new Course("72#Journalism#07*28*2019#5#20#4"),
                new Course("73#Classical literature#06*18*2019#4#23#57"),
                new Course("74#Driver’s Education#03*22*2018#12#2#49"),
                new Course("75#Sociology#02*23*2018#14#17#74"),
                new Course("76#Bowling#10*18*2017#1#21#57"),
                new Course("77#Web Design#01*24*2018#13#22#6"),
                new Course("78#Personal Organization#04*22*2019#9#3#73"),
                new Course("79#Vocabulary#03*24*2019#13#5#65"),
                new Course("80#English III#03*30*2019#4#21#37"),
                new Course("81#Film as Literature#05*04*2018#8#13#8"),
                new Course("82#World Literature#04*06*2019#14#12#57"),
                new Course("83#Yearbook#06*11*2018#2#22#58"),
                new Course("84#Lifeskills#02*05*2018#10#16#35"),
                new Course("85#Drill Team, Honor#02*02*2019#11#15#27"),
                new Course("86#Health#08*09*2018#12#20#31"),
                new Course("87#Archery#10*14*2018#9#20#15"),
                new Course("88#Pre-Algebra#09*11*2017#2#3#76"),
                new Course("89#Rock Climbing#12*25*2017#5#3#56"),
                new Course("90#Personal Finance and Investing#04*04*2018#14#23#28"),
                new Course("91#Dance#06*21*2019#13#21#85"),
                new Course("92#Art IV#10*26*2018#9#1#42"),
                new Course("93#Logic II#05*10*2018#8#19#24"),
                new Course("94#Physical Fitness#02*07*2018#11#13#86"),
                new Course("95#Hiking#02*24*2019#3#17#18"),
                new Course("96#Gardening#05*13*2019#14#18#28"),
                new Course("97#Remedial Math#09*03*2018#2#18#78"),
                new Course("98#Fencing#01*14*2019#15#3#58"),
                new Course("99#Film Production#11*17*2017#3#18#18"),
                new Course("100#Photography#01*07*2019#6#9#51"),
            });


            modelBuilder.Entity<GradeBook>().HasData(new GradeBook[]
            {
new GradeBook("1#7#395#69#4#1"),
new GradeBook("2#19#388#86#4#5"),
new GradeBook("3#36#396#90#1#2"),
new GradeBook("4#52#436#72#4#1"),
new GradeBook("5#28#409#92#5#2"),
new GradeBook("6#15#415#9#3#5"),
new GradeBook("7#87#414#11#2#3"),
new GradeBook("8#56#399#40#1#4"),
new GradeBook("9#52#397#65#5#5"),
new GradeBook("10#29#407#10#2#3"),
new GradeBook("11#51#402#87#3#1"),
new GradeBook("12#20#404#66#4#2"),
new GradeBook("13#60#416#52#5#3"),
new GradeBook("14#50#401#43#3#2"),
new GradeBook("15#100#469#100#3#1"),
new GradeBook("16#92#389#91#1#2"),
new GradeBook("17#60#437#55#3#2"),
new GradeBook("18#96#462#95#3#2"),
new GradeBook("19#90#464#96#4#1"),
new GradeBook("20#99#404#79#2#1"),
new GradeBook("21#45#444#54#4#2"),
new GradeBook("22#22#437#37#4#5"),
new GradeBook("23#73#381#96#1#3"),
new GradeBook("24#26#434#75#2#1"),
new GradeBook("25#74#424#34#4#2"),
new GradeBook("26#36#425#48#5#5"),
new GradeBook("27#25#451#49#4#2"),
new GradeBook("28#10#398#35#5#1"),
new GradeBook("29#65#404#32#1#3"),
new GradeBook("30#99#430#46#4#5"),
new GradeBook("31#99#418#18#3#5"),
new GradeBook("32#83#418#80#5#1"),
new GradeBook("33#99#431#18#5#1"),
new GradeBook("34#48#416#4#2#1"),
new GradeBook("35#32#421#92#2#3"),
new GradeBook("36#30#394#24#1#1"),
new GradeBook("37#76#432#24#2#1"),
new GradeBook("38#18#447#89#1#3"),
new GradeBook("39#14#387#71#1#1"),
new GradeBook("40#40#454#78#1#3"),
new GradeBook("41#29#456#57#5#2"),
new GradeBook("42#4#454#4#5#5"),
new GradeBook("43#93#400#75#2#5"),
new GradeBook("44#73#401#29#1#3"),
new GradeBook("45#16#455#27#3#1"),
new GradeBook("46#73#407#37#3#3"),
new GradeBook("47#75#447#83#3#2"),
new GradeBook("48#2#427#20#4#1"),
new GradeBook("49#94#464#55#1#2"),
new GradeBook("50#33#426#64#5#5"),
new GradeBook("51#49#430#95#4#4"),
new GradeBook("52#96#455#80#2#5"),
new GradeBook("53#22#439#28#4#1"),
new GradeBook("54#51#377#14#5#1"),
new GradeBook("55#16#452#15#2#4"),
new GradeBook("56#15#387#11#2#4"),
new GradeBook("57#54#432#40#2#5"),
new GradeBook("58#36#441#5#2#2"),
new GradeBook("59#83#455#69#4#2"),
new GradeBook("60#76#429#76#1#2"),
new GradeBook("61#78#432#83#5#1"),
new GradeBook("62#65#426#36#4#4"),
new GradeBook("63#20#422#78#1#4"),
new GradeBook("64#79#462#45#2#5"),
new GradeBook("65#56#437#69#5#4"),
new GradeBook("66#79#434#44#1#3"),
new GradeBook("67#6#462#17#2#5"),
new GradeBook("68#75#400#90#1#5"),
new GradeBook("69#61#399#28#2#5"),
new GradeBook("70#54#470#43#2#3"),
new GradeBook("71#86#385#48#1#4"),
new GradeBook("72#96#446#78#1#1"),
new GradeBook("73#93#374#70#1#1"),
new GradeBook("74#99#414#32#5#1"),
new GradeBook("75#16#464#34#2#2"),
new GradeBook("76#86#382#70#2#5"),
new GradeBook("77#14#446#4#2#3"),
new GradeBook("78#52#394#38#1#3"),
new GradeBook("79#40#410#30#3#5"),
new GradeBook("80#10#401#69#5#2"),
new GradeBook("81#83#467#23#3#1"),
new GradeBook("82#45#401#53#1#3"),
new GradeBook("83#77#421#81#5#3"),
new GradeBook("84#30#383#69#5#5"),
new GradeBook("85#56#381#26#4#3"),
new GradeBook("86#21#401#97#5#2"),
new GradeBook("87#27#469#17#2#5"),
new GradeBook("88#69#393#49#1#4"),
new GradeBook("89#63#464#5#1#4"),
new GradeBook("90#22#439#35#3#1"),
new GradeBook("91#64#465#62#3#1"),
new GradeBook("92#34#458#85#1#3"),
new GradeBook("93#92#389#89#5#4"),
new GradeBook("94#81#457#16#2#5"),
new GradeBook("95#30#411#72#1#5"),
new GradeBook("96#80#458#43#4#2"),
new GradeBook("97#60#429#36#5#5"),
new GradeBook("98#75#393#63#3#2"),
new GradeBook("99#21#426#53#4#2"),
new GradeBook("100#94#451#10#3#1"),
new GradeBook("101#72#390#11#1#4"),
new GradeBook("102#92#447#1#5#4"),
new GradeBook("103#84#396#77#5#5"),
new GradeBook("104#13#420#20#5#5"),
new GradeBook("105#72#426#89#4#2"),
new GradeBook("106#63#428#48#5#3"),
new GradeBook("107#33#442#36#4#2"),
new GradeBook("108#32#416#93#4#5"),
new GradeBook("109#29#386#79#5#1"),
new GradeBook("110#33#450#20#1#4"),
new GradeBook("111#81#429#62#2#5"),
new GradeBook("112#90#389#31#1#3"),
new GradeBook("113#15#406#26#2#1"),
new GradeBook("114#50#424#8#5#3"),
new GradeBook("115#54#426#31#3#2"),
new GradeBook("116#78#418#66#4#3"),
new GradeBook("117#83#445#71#4#1"),
new GradeBook("118#48#460#45#5#5"),
new GradeBook("119#99#469#4#2#4"),
new GradeBook("120#26#457#51#1#5"),
new GradeBook("121#84#414#9#3#5"),
new GradeBook("122#68#376#19#1#3"),
new GradeBook("123#93#441#54#2#3"),
new GradeBook("124#4#472#44#4#1"),
new GradeBook("125#62#377#63#1#4"),
new GradeBook("126#45#417#82#3#2"),
new GradeBook("127#52#440#31#1#4"),
new GradeBook("128#19#438#42#3#1"),
new GradeBook("129#73#393#28#3#2"),
new GradeBook("130#68#449#94#3#5"),
new GradeBook("131#20#425#80#3#4"),
new GradeBook("132#73#457#48#5#1"),
new GradeBook("133#20#375#12#2#5"),
new GradeBook("134#74#431#75#4#4"),
new GradeBook("135#28#445#99#1#5"),
new GradeBook("136#31#385#83#1#4"),
new GradeBook("137#77#435#25#2#2"),
new GradeBook("138#91#441#40#5#3"),
new GradeBook("139#6#414#42#2#3"),
new GradeBook("140#67#438#55#2#1"),
new GradeBook("141#66#375#23#2#1"),
new GradeBook("142#77#453#35#2#2"),
new GradeBook("143#21#379#74#1#4"),
new GradeBook("144#26#467#50#4#4"),
new GradeBook("145#13#461#44#2#2"),
new GradeBook("146#77#414#58#2#1"),
new GradeBook("147#53#406#67#3#5"),
new GradeBook("148#14#423#15#4#5"),
new GradeBook("149#82#441#93#5#1"),
new GradeBook("150#94#445#91#2#1"),
new GradeBook("151#60#423#81#2#5"),
new GradeBook("152#45#454#58#1#1"),
new GradeBook("153#75#446#7#1#4"),
new GradeBook("154#15#455#7#4#4"),
new GradeBook("155#75#416#97#3#3"),
new GradeBook("156#19#397#67#4#3"),
new GradeBook("157#48#386#96#4#4"),
new GradeBook("158#79#447#73#3#1"),
new GradeBook("159#63#436#94#3#3"),
new GradeBook("160#67#434#87#4#5"),
new GradeBook("161#9#384#21#4#4"),
new GradeBook("162#63#406#15#4#5"),
new GradeBook("163#87#407#80#5#3"),
new GradeBook("164#73#466#97#2#1"),
new GradeBook("165#55#376#42#3#5"),
new GradeBook("166#3#430#12#2#4"),
new GradeBook("167#51#373#32#2#1"),
new GradeBook("168#82#401#20#5#5"),
new GradeBook("169#51#426#14#4#2"),
new GradeBook("170#49#450#71#1#1"),
new GradeBook("171#20#422#39#2#4"),
new GradeBook("172#2#436#73#2#1"),
new GradeBook("173#44#446#68#5#3"),
new GradeBook("174#50#410#32#5#1"),
new GradeBook("175#17#402#53#5#4"),
new GradeBook("176#44#464#20#5#4"),
new GradeBook("177#74#392#84#1#4"),
new GradeBook("178#13#409#77#1#3"),
new GradeBook("179#3#418#65#2#2"),
new GradeBook("180#73#430#76#1#1"),
new GradeBook("181#23#445#99#2#2"),
new GradeBook("182#83#415#24#4#2"),
new GradeBook("183#72#437#28#5#4"),
new GradeBook("184#16#460#34#2#5"),
new GradeBook("185#92#419#66#2#2"),
new GradeBook("186#76#439#65#5#4"),
new GradeBook("187#7#468#95#1#3"),
new GradeBook("188#22#412#36#5#5"),
new GradeBook("189#22#444#85#4#2"),
new GradeBook("190#63#414#75#5#4"),
new GradeBook("191#41#438#98#3#3"),
new GradeBook("192#6#395#18#3#1"),
new GradeBook("193#81#435#65#3#2"),
new GradeBook("194#78#434#35#5#1"),
new GradeBook("195#79#469#33#4#2"),
new GradeBook("196#79#386#61#2#2"),
new GradeBook("197#81#463#27#4#1"),
new GradeBook("198#46#464#87#4#3"),
new GradeBook("199#52#408#32#1#3"),
new GradeBook("200#40#455#12#2#2"),
            });

        }

    }
}
