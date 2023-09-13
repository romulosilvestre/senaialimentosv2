namespace SenaiAlimentos.Models;

public class Nivel{  
   public int Id { get; set; }
   public string? Name { get; set; }

    public Nivel(string? name){
         Name = name;
    }
    public Nivel(){
      
    }
}

