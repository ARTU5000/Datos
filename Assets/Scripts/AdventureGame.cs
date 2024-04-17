using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AdventureGame : MonoBehaviour
{
    private int SPECIAL;
    private int Strenght;
    private int Perception;
    private int Endurance;
    private int Charisma;
    private int Inteligence;
    private int Agility;
    private int Luck;
    private int atribute;
    private bool WinLoose;
    private int story = 0;

    private void Start()
    {
        StartGame();
        STORY();
    }

    private void StartGame()
    {
        SPECIAL = 25;
        stats();
    }

    private void cut()
    {
        Debug.Log("------------------------------------------------------------------------------------------------------------------------------------");
    }

    private int random(int min, int max)
    {
        return Random.Range(min, max + 1);
    }

    private void Challenge()
    {
        int rand;
        int AcDes;
        string enter;

        Debug.Log("6 puntos necesarios");
        Debug.Log("Escribe algo y presiona 'Enter' para continuar.");
        enter = Console.ReadLine();
        rand = random(1, 6);
        AcDes = atribute + rand;
        Debug.Log("Conseguiste " + AcDes + " puntos");

        if (AcDes >= 6)
        {
            WinLoose = true;
            Debug.Log("Pasaste el desafio");
        }
        else
        {
            WinLoose = false;
            Debug.Log("Uy... no fue suficiente...");
        }
    }

    private void STORY()
    {
        switch (story)
    {
        case 0:
            Debug.Log("Habias terminado de explorar unas ruinas, la entrada que usaste se habia derrumbado.");
            Debug.Log("Pero descubriste un camino que no aparecia en los pergaminos antiguos, con suerte una salida secreta.");
            Debug.Log("Avanzas por el camino hasta llegas al tunel de una cueva...");
            Debug.Log("Desafio de PERCEPCION");
            atribute = Perception;
            Challenge();
            story = WinLoose ? 2 : 1;
            cut();
            STORY();
            break;

        case 1:
            Debug.Log("Avanzas por la cueva pero no notas el cable de una trampa hasta que lo pisas y activas el mecanismo...");
            Debug.Log("Desafio de AGILIDAD");
            atribute = Agility;
            Challenge();
            story = WinLoose ? 2 : 4;
            cut();
            STORY();
            break;

        case 2:
            Debug.Log("Evitas una trampa y continuas con cuidado, los ojos abiertos en busca de mas trampas");
            Debug.Log("Llegas a lo que parece un campamento de saqueadores dentro de la cueva");
            Debug.Log("Te acercas con cuidado, parece que los saqueadores no estan aqui y con suerte podras llevarte algo valioso...");
            Debug.Log("Desafio de SUERTE");
            atribute = Luck;
            Challenge();
            story = WinLoose ? 6 : 3;
            cut();
            STORY();
            break;

        case 3:
            Debug.Log("Lamentablemente las cosas valiosas estan tras una cerradura");
            Debug.Log("Buscas en tus alrededores quiza encuentres algo para abrir la cerradura");
            Debug.Log("Hay algunas cosas que te pueden servir para forzar la cerradura, si es que sabes como utilizarlas...");
            Debug.Log("Desafio de INTELIGENCIA");
            atribute = Inteligence;
            Challenge();
            story = WinLoose ? 6 : 8;
            cut();
            STORY();
            break;

        case 4:
            Debug.Log("No lagras evitar la trampa a tiempo y te enredan entre varias cuerdas colgando boca abajo.");
            Debug.Log("Quiza puedas decifrar como salir de la trampa...");
            Debug.Log("Desafio de INTELIGENCIA");
            atribute = Inteligence;
            Challenge();
            story = WinLoose ? 10 : 5;
            cut();
            STORY();
            break;

        case 5:
            Debug.Log("No tienes el conocimiento suficiente para salir de la trampa, solo te queda intentar forzarla...");
            Debug.Log("Desafio de FUERZA");
            atribute = Strenght;
            Challenge();
            story = WinLoose ? 10 : 12;
            cut();
            STORY();
            break;

        case 6:
            Debug.Log("Consigues un botin bastante bueno y contimuas hacia la salida de la cueva, seguramente valdra mucho en la ciudad.");
            Debug.Log("Al salir caminas un tiempo hasta llegar a un camino, tras un tiempo escuchas a alguien viajando a caballo");
            Debug.Log("Ojala puedas convencerle de llevarte a la ciudad mas cercana...");
            Debug.Log("Desafio de CARISMA");
            atribute = Charisma;
            Challenge();
            if (WinLoose)
            {
                cut();
                Debug.Log("Logras convencer al soldado de cambiar su ruta y llevarte");
                Debug.Log("Unas horas mas tarde llegas a la ciudad, encuentras un comerciante que te acepta lo que sacaste de la cueva");
                Debug.Log("Despues de vender el botin tienes suficiente dinero para disfrutar de unas vacaciones.");
                story = 14;
            }
            else
            {
                story = 7;
            }
            cut();
            STORY();
            break;

        case 7:
            Debug.Log("Lamentablemente no pudiste convencer al soldado que pasaba");
            Debug.Log("Ni siquiera por una parte del botin");
            Debug.Log("No te queda mas que caminar a la ciudad mas cercana...");
            Debug.Log("Desafio de RESISTENCIA");
            atribute = Endurance;
            Challenge();
            if (WinLoose)
            {
                cut();
                Debug.Log("Por suerte esta en forma y no sientes mucho cansancio aún");
                Debug.Log("Varias horas mas tarde llegas a la ciudad, encuentras un comerciante que te acepta lo que sacaste de la cueva");
                Debug.Log("Despues de vender el botin tienes suficiente dinero para disfrutar de unas vacaciones.");
                story = 14;
            }
            else
            {
                cut();
                Debug.Log("Lamentablemente no estas en tan buena forma y ya sientes bastante cansancio");
                Debug.Log("Avanzas por el camino pero se te hace tarde despues de un tiempo y la ciudad aun esta lejos");
                Debug.Log("Parece que tendras que buscar un lugar donde pasar la noche.");
                story = 14;
            }
            cut();
            STORY();
            break;

        case 8:
            Debug.Log("No logras abrir la cerradura y pasas mas tiempo intentando del que tenias en mente...");
            Debug.Log("Desafio de PERCEPCION");
            atribute = Perception;
            Challenge();
            if (WinLoose)
            {
                cut();
                Debug.Log("Sientes que ya pasaste mucho tiempo intentando y probablemente los saqueadores regresen pronto.");
                Debug.Log("Sales con cuidado de la cueva y a una buena distancia ves como un grupo de saqueadores regresa.");
                Debug.Log("Habiendo evitado a los saqueadores por poco, emprendes tu camino a la ciudad.");
                story = 14;
            }
            else
            {
                story = 9;
            }
            cut();
            STORY();
            break;

        case 9:
            Debug.Log("Pasaste mucho tiempo con las cerraduras y los saqueadores regresaron.");
            Debug.Log("Agarras una espada que se encontraba a tu alcance.");
            Debug.Log("Solo tienes una forma para salir de aqui, a travez de ellos...");
            Debug.Log("Desafio de FUERZA");
            atribute = Strenght;
            Challenge();
            if (WinLoose)
            {
                cut();
                Debug.Log("Tu destreza y fuerza en combate supera a los saqueadores.");
                Debug.Log("Encuentras la llave de la cerradura en el cuerpo o lo que queda de uno de ellos.");
                Debug.Log("Sales de la cueva con todas las cosas valiosas que encontraste.");
                story = 14;
            }
            else
            {
                cut();
                Debug.Log("Lamentablemente no lograste acabar con los saqueadores y acabaron contigo.");
                Debug.Log("Fin.");
                story = 15;
            }
            cut();
            STORY();
            break;

        case 10:
            Debug.Log("No lograste salir de la trampa a tiempo y te atrapan los saqueadores que estaban cerca.");
            Debug.Log("Parece que no te dejaran salir sin pelear...");
            Debug.Log("Desafio de FUERZA");
            atribute = Strenght;
            Challenge();
            if (WinLoose)
            {
                cut();
                Debug.Log("Con gran esfuerzo logras escapar de los saqueadores.");
                Debug.Log("Pero con la prisa de la huida te perdiste y te tomo varias horas llegar a la ciudad.");
                Debug.Log("Al final llegas a la ciudad y consigues vender todo el botin, suficiente para un buen descanso.");
                story = 14;
            }
            else
            {
                cut();
                Debug.Log("Los saqueadores eran demasiado para ti y terminaste sucumbiendo a sus ataques.");
                Debug.Log("Fin.");
                story = 15;
            }
            cut();
            STORY();
            break;

        case 11:
            Debug.Log("Los saqueadores no se percatan de tu presencia y te toman por sorpresa.");
            Debug.Log("No tienes tiempo de reaccionar antes de que te ataquen...");
            Debug.Log("Desafio de SUERTE");
            atribute = Luck;
            Challenge();
            if (WinLoose)
            {
                cut();
                Debug.Log("Por suerte uno de ellos te reconocio y deciden no seguir peleando.");
                Debug.Log("Te dan un amistoso recordatorio de que no vuelvas por alli.");
                Debug.Log("Sales de la cueva con todas las cosas valiosas que encontraste.");
                story = 14;
            }
            else
            {
                cut();
                Debug.Log("Lamentablemente la suerte no estuvo de tu lado y terminaste sucumbiendo a sus ataques.");
                Debug.Log("Fin.");
                story = 15;
            }
            cut();
            STORY();
            break;

        case 12:
            Debug.Log("La trampa es demasiado fuerte y no puedes salir de ella.");
            Debug.Log("Estas demasiado cansado para seguir intentandolo.");
            Debug.Log("Desafio de RESISTENCIA");
            atribute = Endurance;
            Challenge();
            if (WinLoose)
            {
                cut();
                Debug.Log("Por suerte aun tienes fuerzas para intentar salir de la trampa.");
                Debug.Log("Finalmente logras liberarte y continuas tu camino hacia la ciudad.");
                story = 14;
            }
            else
            {
                cut();
                Debug.Log("Desafortunadamente el cansancio es demasiado y terminas rindiendote.");
                Debug.Log("Fin.");
                story = 15;
            }
            cut();
            STORY();
            break;

        case 13:
            Debug.Log("No puedes ver mucho y terminas atrapado por los saqueadores que regresaban a su campamento.");
            Debug.Log("No te dejaran salir sin pelear...");
            Debug.Log("Desafio de AGILIDAD");
            atribute = Agility;
            Challenge();
            if (WinLoose)
            {
                cut();
                Debug.Log("Con gran esfuerzo logras escapar de los saqueadores.");
                Debug.Log("Pero con la prisa de la huida te perdiste y te tomo varias horas llegar a la ciudad.");
                Debug.Log("Al final llegas a la ciudad y consigues vender todo el botin, suficiente para un buen descanso.");
                story = 14;
            }
            else
            {
                cut();
                Debug.Log("Los saqueadores eran demasiado para ti y terminaste sucumbiendo a sus ataques.");
                Debug.Log("Fin.");
                story = 15;
            }
            cut();
            STORY();
            break;

        case 14:
            Debug.Log("¡Felicidades! Has completado tu aventura con éxito.");
            Debug.Log("Fin.");
            break;

        case 15:
            Debug.Log("¡Oh no! Has fallado en tu aventura.");
            Debug.Log("Fin.");
            break;
        }
    }

    private void stats()
    {
        cut();

        Debug.Log("Fuerza: " + Strenght);
        Debug.Log("Percepcion: " + Perception);
        Debug.Log("Resistencia: " + Endurance);
        Debug.Log("Carisma: " + Charisma);
        Debug.Log("Inteligencia: " + Inteligence);
        Debug.Log("Agilidad: " + Agility);
        Debug.Log("Suerte: " + Luck);

        Debug.Log("Tus atributos te ayudaran a superar desafios");
        Debug.Log("Para superar desafios se suma un valor aleatorio y el valor de tu atributo y esto debe ser mayor al valor del desafio");

        cut();
        Customize();
    }

    private void Customize()
    {
        int a = 0;
        Debug.Log("tienes " + SPECIAL + " puntos para tus atributos.");
        Debug.Log("Puedes dejar puntos sin utilizar para aumentar la dificultad");
        Debug.Log("Escribe un valor entre 0 y 5 para tus puntos de Fuerza.");
        a = Convert.ToInt32(Console.ReadLine());

       int remainingPoints = SPECIAL;

       Debug.Log("- Fuerza");
       Debug.Log("- Percepción");
       Debug.Log("- Resistencia");
       Debug.Log("- Carisma");
       Debug.Log("- Inteligencia");
       Debug.Log("- Agilidad");
       Debug.Log("- Suerte");
       Debug.Log("Personaliza la distribución de puntos de habilidad para tu personaje:");

       Debug.Log("Por favor, ingresa la cantidad de puntos que deseas asignar a cada atributo:");

       Debug.Log("Fuerza:");
       Strenght = Mathf.Clamp(int.Parse(Console.ReadLine()), 0, 5);
       remainingPoints -= Strenght;

       Debug.Log("Percepción:");
       Perception = Mathf.Clamp(int.Parse(Console.ReadLine()), 0, 5);
       remainingPoints -= Perception;

       Debug.Log("Resistencia:");
       Endurance = Mathf.Clamp(int.Parse(Console.ReadLine()), 0, 5);
       remainingPoints -= Endurance;

       Debug.Log("Carisma:");
       Charisma = Mathf.Clamp(int.Parse(Console.ReadLine()), 0, 5);
       remainingPoints -= Charisma;

       Debug.Log("Inteligencia:");
       Inteligence = Mathf.Clamp(int.Parse(Console.ReadLine()), 0, 5);
       remainingPoints -= Inteligence;

       Debug.Log("Agilidad:");
       Agility = Mathf.Clamp(int.Parse(Console.ReadLine()), 0, 5);
       remainingPoints -= Agility;

       Debug.Log("Suerte:");
       Luck = Mathf.Clamp(int.Parse(Console.ReadLine()), 0, Mathf.Min(remainingPoints, 5));
       remainingPoints -= Luck;

       Debug.Log("¡Tu personaje ha sido personalizado con éxito!");
    }
}
