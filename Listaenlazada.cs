using System;

public class Nodo{ // creo la clase nodo
    public int valor ;   // creo el valor y la referencia al siguiente nodo
    public Nodo siguiente;

    public Nodo (int valor){
        this.valor = valor;     // creo el constructor
        this.siguiente = null;
    }

}

public class Listaenlazada{

    Nodo principio, final; // creo el principio y el final y el largo de la lista
    public int largodelista;

    public Listaenlazada(){ // creo el constructor
        principio = null;
        final = null;
        largodelista = 0;
        
    }

    public void AgregarAlprincipio(int valor){ //funcion para agregar al principio 
        Nodo nuevonodo = new Nodo(valor);
        if (principio == null)
        {    
            principio = nuevonodo;  // si principio es null el nuevo valor es principio y final
            final = nuevonodo;
            largodelista++; // el largo de la lista aumenta
        }
        else
        {
            nuevonodo.siguiente = principio; // el nuevo nodo apunta al principio
            principio = nuevonodo; // y el principio ahora es igual al nuevo nodo
            largodelista++;
        }
        
    }
    
    public void AgregarAlFinal(int valor)  // agregar al final
    {
        Nodo nuevonodo = new Nodo(valor); 
        if (final == null)
        {
            principio = nuevonodo;  // si esta vacia creo el nodo nuevo
            final = nuevonodo;
            largodelista++;
        }
        else
        {
            final.siguiente = nuevonodo;   // inserto el nodo al final
            final = nuevonodo;  
            largodelista++; 
        }
    }


    public void AgregarNodoporindice(int valor, int posicion){
        Nodo nuevonodo = new Nodo(valor);
        int contador = 2; // creo un contador


        if(posicion > largodelista + 1 || posicion <= 0){
            Console.WriteLine("Ingrese numeros validos, el tamaño de la lista es de" + largodelista);
            return;  // si el indice no es valido se manda un texto
        }
        
        else if(posicion == 1){ // si posicion es 1 se inserta al inicio 
            if (principio == null)
        {
            principio = nuevonodo;  
            final = nuevonodo;  // si esta vacio se crea el nodo
            largodelista++;
        }
        else
        {
            nuevonodo.siguiente = principio; // si no esta vacio se inserta al inicio
            principio = nuevonodo;
            largodelista++;
        }
            return;

        }
        else if (posicion > 1 && posicion <= largodelista + 1){ // insertar enntre el principio y el final
            Nodo nodoactual = principio.siguiente;
            Nodo nodoanterior = principio;  // creo nodo anterior y nodo actual
        
            while(nodoactual != null && posicion > 1){ // si posicion es valido y no he recorrido todo el nodo
                
                if(contador == posicion){ // si el contador que tengo es igual a la posicion
                    nodoanterior.siguiente = nuevonodo;  // se inserta el nodo entre anterior y actual
                    nuevonodo.siguiente = nodoactual;
                    largodelista++;
                    return;
                }
                nodoactual = nodoactual.siguiente;
                nodoanterior = nodoanterior.siguiente; // se pasa al siguiente nodo anterior y al siguiente actual
                contador++;
            }

            if(posicion == largodelista + 1){ // si quiero insertar al final
               
            final.siguiente = nuevonodo;  
            final = nuevonodo;   // inserto el nodo al final
            largodelista++;
            }
        }


    }


    public void EliminarPorIndice(int posicion)
    {
        if (principio == null) // si no hay nodos se manda un texto
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }
        if (posicion == 1)  //si la posicion es 1 se elimina
        {

            principio = principio.siguiente;
            largodelista--;
            return;
        }
        
        Nodo actual = principio; // se crean 2 nodos uno actual y uno anterior
        Nodo anterior = null;
        int contador = 1;
        
        while (actual != null && contador < posicion) // recorro toda la lista hata la posicion deseada
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
        
        anterior.siguiente = actual.siguiente; // borro el actual
        largodelista--;
        
        if (actual == final) // si actual era el ultimo final ahora es igual al anterior
        { 
            final = anterior;
        }
    }




    public void Imprimir()
    {
        if (principio == null) // si esta vacia mando un mensaje
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo nodoActual = principio;
        while (nodoActual != null)  // recorro toda la lista hasta imprimir
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
       Listaenlazada Listaenlazada = new Listaenlazada();  // inicializo la lista


        do{
    Console.WriteLine("1. añadir al inicio de la lista ");
    Console.WriteLine("2. añadir al final de la lista");  // creo el menu
    Console.WriteLine("3. añadir por posicion");
    Console.WriteLine("4. eliminar por posicion");
    Console.WriteLine("5. eliminar inicio");
    Console.WriteLine("6. eliminar final");
    Console.WriteLine("7. imprimir");
    numero = int.Parse(Console.ReadLine()); // pido un numero
    if(numero == 1){
        Console.WriteLine("ingresa valor: "); // veo que numero concuerda con el menu
    valor = int.Parse(Console.ReadLine()); 
        Listaenlazada.AgregarAlprincipio(valor);
    }
    else if(numero == 2){

        Console.WriteLine("ingresa valor: ");
        valor = int.Parse(Console.ReadLine());  
        Listaenlazada.AgregarAlFinal(valor);
    }
     else if(numero == 3){                          // lamo las funciones
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

    Console.WriteLine("quieres seguir con el programa?s/n");  // verifico si quiero seguir con el programa
    sn = Console.ReadLine();
    if(sn != "n"){
        estado = true;
    }
    else{
        estado = false;
    }
    }
    while(estado); // uso un do-while para el menu

    }

    }
