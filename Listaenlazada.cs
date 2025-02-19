using System;

public class Nodo{
    public int valor ;
    public Nodo siguiente;

    public Nodo (int valor){
        this.valor = valor;
        this.siguiente = null;
    }

}

public class Listaenlazada{

    Nodo principio, final;
    public int largodelista;

    public Listaenlazada(){
        principio = null;
        final = null;
        largodelista = 0;
        
    }

    public void AgregarAlprincipio(int valor){
        Nodo nuevonodo = new Nodo(valor);
        if (principio == null)
        {
            principio = nuevonodo;  
            final = nuevonodo;
            largodelista++;
        }
        else
        {
            nuevonodo.siguiente = principio;
            principio = nuevonodo;
            largodelista++;
        }
        
    }
    
    public void AgregarAlFinal(int valor)
    {
        Nodo nuevonodo = new Nodo(valor);
        if (final == null)
        {
            principio = nuevonodo;  
            final = nuevonodo;
            largodelista++;
        }
        else
        {
            final.siguiente = nuevonodo;  
            final = nuevonodo;  
            largodelista++; 
        }
    }


    public void AgregarNodoporindice(int valor, int posicion){
        Nodo nuevonodo = new Nodo(valor);
        int contador = 2;


        if(posicion > largodelista + 1 || posicion <= 0){
            Console.WriteLine("Ingrese numeros validos, el tamaño de la lista es de" + largodelista);
            return;
        }
        
        else if(posicion == 1){
            if (principio == null)
        {
            principio = nuevonodo;  
            final = nuevonodo;
            largodelista++;
        }
        else
        {
            nuevonodo.siguiente = principio;
            principio = nuevonodo;
            largodelista++;
        }
            return;

        }
        else if (posicion > 1 && posicion <= largodelista + 1){
            Nodo nodoactual = principio.siguiente;
            Nodo nodoanterior = principio;
        
            while(nodoactual != null && posicion > 1){
                
                if(contador == posicion){
                    nodoanterior.siguiente = nuevonodo;
                    nuevonodo.siguiente = nodoactual;
                    largodelista++;
                    return;
                }
                nodoactual = nodoactual.siguiente;
                nodoanterior = nodoanterior.siguiente;
                contador++;
            }

            if(posicion == largodelista + 1){
               
            final.siguiente = nuevonodo;  
            final = nuevonodo;  
            largodelista++;
            }
        }


    }


    public void EliminarPorIndice(int posicion)
    {
        if (principio == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }
        if (posicion == 1)
        {

            principio = principio.siguiente;
            largodelista--;
            return;
        }
        
        Nodo actual = principio;
        Nodo anterior = null;
        int contador = 1;
        
        while (actual != null && contador < posicion)
        {
            anterior = actual;
            actual = actual.siguiente;
            contador++;
        }
        
        if (actual == null)
        {
            Console.WriteLine("Posición fuera de rango.");
            return;
        }
        
        anterior.siguiente = actual.siguiente;
        largodelista--;
        
        if (actual == final)
        {
            final = anterior;
        }
    }




    public void Imprimir()
    {
        if (principio == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo nodoActual = principio;
        while (nodoActual != null)
        {
            Console.Write(nodoActual.valor + " ");
            nodoActual = nodoActual.siguiente;
        }
        Console.WriteLine();
    }



}


class Program
{
    static void Main(string[] args)
    {
        bool estado;
        string sn;
        int numero = 0;
        int valor = 0;
        int posicion = 0;
       Listaenlazada Listaenlazada = new Listaenlazada(); 


        do{
    Console.WriteLine("1. añadir al inicio de la lista ");
    Console.WriteLine("2. añadir al final de la lista"); 
    Console.WriteLine("3. añadir por posicion");
    Console.WriteLine("4. eliminar por posicion");
    Console.WriteLine("5. eliminar inicio");
    Console.WriteLine("6. eliminar final");
    Console.WriteLine("7. imprimir");
    numero = int.Parse(Console.ReadLine()); 
    if(numero == 1){
        Console.WriteLine("ingresa valor: ");
    valor = int.Parse(Console.ReadLine()); 
        Listaenlazada.AgregarAlprincipio(valor);
    }
    else if(numero == 2){

        Console.WriteLine("ingresa valor: ");
        valor = int.Parse(Console.ReadLine()); 
        Listaenlazada.AgregarAlFinal(valor);
    }
     else if(numero == 3){
        Console.WriteLine("ingresa valor: ");
        valor = int.Parse(Console.ReadLine()); 
         Console.WriteLine("ingresa posicion: ");
        posicion = int.Parse(Console.ReadLine()); 
        Listaenlazada.AgregarNodoporindice(valor,posicion);
    }
    else if (numero == 4){
        Console.WriteLine("ingresa posicion: ");
        posicion = int.Parse(Console.ReadLine()); 
        Listaenlazada.EliminarPorIndice(posicion);
    }
    else if (numero == 5 ){
        
        Listaenlazada.EliminarPorIndice(1);
    }
     else if (numero == 6 ){
        
        Listaenlazada.EliminarPorIndice(Listaenlazada.largodelista);
    }
    
    else if (numero == 7){
        Listaenlazada.Imprimir();
    }

    Console.WriteLine("quieres seguir con el programa?s/n"); 
    sn = Console.ReadLine();
    if(sn != "n"){
        estado = true;
    }
    else{
        estado = false;
    }
    }
    while(estado);

    }

    }
