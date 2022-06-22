using AplikacjaWieloAgenty.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaWieloAgenty
{
    public class GameConext : DbContext
    {
        public GameConext()
        {

        }
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=C:\\Users\\Alek\\source\\repos\\AplikacjaWieloAgenty\\AplikacjaWieloAgenty\\TestDataBase.db");
        }

        /*-- Script Date: 21/06/2022 18:57  - ErikEJ.SqlCeScripting version 3.5.2.94
INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
VALUES('F1 2021',1,3,3,2,3,1,0,0,0,2,1,3,2,3,2);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Assetto Corsa',1,1,3,0,1,2,3,0,3,2,2,1,1,0,3);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Grid 2',2,3,2,3,1,0,0,0,3,1,1,3,2,3,1);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Forza Horizon 5',2,3,2,3,2,0,0,2,3,1,3,2,2,3,1);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Iracing',0,1,3,0,0,2,3,1,3,3,2,1,3,0,3);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Dirt Rally 2.0',1,2,3,0,2,3,1,3,0,0,3,3,1,1,3);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Assetto Corsa Competitzione',1,1,3,0,1,2,3,0,3,0,1,3,2,1,3);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Forza Motosport 7',2,3,3,2,3,1,0,0,3,0,1,3,0,3,1);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('WRC 10',1,2,3,0,1,2,3,3,0,0,3,2,1,1,2);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('BeamNG',1,2,3,0,2,3,1,3,3,0,3,1,0,3,2);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Automobilista 2',1,2,3,0,1,2,3,0,3,2,2,3,1,0,2);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('rFactor 2',1,2,3,0,1,2,3,0,3,2,2,3,1,0,2);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('RaceRoom',1,2,3,0,1,2,3,0,3,1,1,0,3,0,2);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Project Cars 3',2,3,1,3,1,0,0,2,3,0,1,3,2,3,1);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Need for Speed',2,3,1,3,1,0,0,0,3,0,3,3,3,3,0);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Wreckfest',1,2,3,2,3,1,0,1,1,0,1,2,3,1,2);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('The Crew 2',2,3,1,3,1,0,0,1,2,0,1,2,3,3,0);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Dirt 5',2,3,1,3,1,0,0,3,0,0,3,2,1,3,1);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('NASCRAC Heat 5',2,3,1,3,2,0,0,0,2,0,0,3,1,3,1);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Art of Rally',2,3,0,3,1,0,0,3,0,0,3,2,0,3,0);
        INSERT INTO[Games] ([Name],[Klawiatura],[Pad],[Kierownica],[Niski],[Sredni],[Trudny],[BardzoTrudny],[Rally],[Sportowe],[OpenWheel],[Brak],[AI],[Online],[Nie],[Tak])
        VALUES('Richard Burns Rally',1,2,3,0,1,2,3,3,0,0,3,0,2,0,3);*/

    }
}
