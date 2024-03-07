internal class Program
{
    private const string V = "";

    private static void Main(string[] args)
    {
        Producto[] productos=new Producto[20];
        int opcion;
        bool controlOpciones=true;
        while(controlOpciones){
            Console.WriteLine("0-Salir");
            Console.WriteLine("1- Agregar Producto");
            Console.WriteLine("2- Mostrar Productos");
            Console.WriteLine("3- Editar un Producto");
            Console.WriteLine("4- Eliminar un Producto");
            Console.WriteLine("5- Mostrar Productos por categoria");
            Console.WriteLine("----------------");
            Console.WriteLine("ingresa un opcion");
            opcion=Convert.ToInt32(Console.ReadLine());
            switch (opcion){
                case 0: Console.WriteLine("Fin Programma");
                        controlOpciones=false;
                        break;
                case 1: Console.WriteLine("Agregando Producto...");
                        productos=AgregarProducto(productos);
                        break;
                case 2: Console.WriteLine("Mostrando Productos...");
                        mostrarProductos(productos);
                        break;
                case 3: Console.WriteLine("Editando un Producto...");
                        productos=editarProducto(productos);
                        break;
                case 4: Console.WriteLine("Eliminando un Producto...");
                        productos=eliminarProducto(productos);
                        break;
                case 5: Console.WriteLine("Mostrando Productos por categoria...");
                        mostrarPorCategoria(productos);
                        break;
            }
        }
    }
    public struct Producto{
        public string nombre;
        public string categoria;
        public float precio;
        public int cantidad;
    }
    //----------------------Agregar Producto--------------------------------------------------------------
    static Producto[] AgregarProducto(Producto[] productos){
        Producto productoNuevo;
        bool control=false;
        foreach(Producto producto in productos){
            if(producto.nombre==null){
                control=true;
                break;
            }
        }
        if(control==true){
            Console.WriteLine("Ingresa el nombre del producto");
            productoNuevo.nombre=Console.ReadLine();
            Console.WriteLine("Ingresa la categoria del producto");
            productoNuevo.categoria=Console.ReadLine();
            Console.WriteLine("Ingresa el precio del Producto");
            productoNuevo.precio=Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Ingresa la cantidad del Producto");
            productoNuevo.cantidad=Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<productos.Length;i++){
                if(productos[i].nombre==null){
                    productos[i]=productoNuevo;
                    break;
                }
            }
            
        }
        else{
           Console.WriteLine("No hay espacio para agregar mas productos");
        }
        return productos;
    }
    //-----------------------------------Eliminar un Producto-------------------------------------------------
    static Producto[] eliminarProducto(Producto[] productos)
    {
        string nombreBorrar;
        string categoriaBorrar;
        bool control = true;
        bool test = true;
        while (control)
        {
            Console.WriteLine("Ingresa el nombre del producto que deseas eliminar");
            nombreBorrar = Console.ReadLine();
            Console.WriteLine("Ingresa la categoria del producto que deseas eliminar");
            categoriaBorrar = Console.ReadLine();
            foreach (Producto producto in productos)
            {
                if (producto.nombre == nombreBorrar && producto.categoria == categoriaBorrar)
                {
                    test = false;
                    
                    break;
                }
            }
            if (test == false)
            {
                for (int i = 0; i < productos.Length; i++)
                {
                    if (productos[i].nombre == nombreBorrar && productos[i].categoria == categoriaBorrar)
                    {
                        productos[i].nombre = "";
                        productos[i].categoria = "";
                        productos[i].precio = 0;
                        productos[i].cantidad = 0;

                        break;
                    }
                }
                control = false;
            }
            else
            {
                Console.WriteLine("Este Producto Con ests datos no existe");
            }
        }
        productos=borrarNull(productos);
        return productos;
    }
    //Este Funcion sirve para eliminar un producto nulo de la lista, y hacer un return de nueva lista sin producto nulo
    static Producto[] borrarNull(Producto[] productos){
        Producto[] productos2 = new Producto[20];
        int indexProductos=0;// Este index nos ayudara a ubicar los Productos en la nueva lista fabrianteProductos2
        for(int i=0;i<productos.Length;i++){
            if(productos[i].nombre!=null){
                productos2[indexProductos]=productos[i];
                indexProductos++;
            }
        }
        return productos2;
        
    }
    //--------------------------------Editar un producto-----------------------------------------------------------
    static Producto[] editarProducto(Producto[] productos)
    {
        string nombreEditar;
        string categoriaEditar;
        bool control = true;
        int opcionEditar;
        while (control){
            Console.WriteLine("Ingresa el nombre del producto que deseas editar");
            nombreEditar = Console.ReadLine();
            Console.WriteLine("Ingresa la categoria del Producto que deseas editar");
            categoriaEditar = Console.ReadLine();
            for(int i=0;i<productos.Length;i++){
                if (productos[i].nombre == nombreEditar && productos[i].categoria == categoriaEditar)
                {
                    do{
                        Console.WriteLine("1. Editar Nombre.\n2. Editar Categoría.\n3. Editar Precio.\n4. Editar Cantidad");
                        Console.WriteLine("Que deseas editar");
                        opcionEditar=Convert.ToInt32(Console.ReadLine());
                    }while(opcionEditar<1 || opcionEditar>4);
                    switch (opcionEditar){
                        case 1: productos[i].nombre=editarNombre(productos[i].nombre);
                                break;
                        case 2: productos[i].categoria=editarCategoria(productos[i].categoria);
                                break;
                        case 3: productos[i].precio=editarPrecio(productos[i].precio);
                                break;
                        default: productos[i].cantidad=editarCantidad(productos[i].cantidad);
                                 break;
                    }
                    control=false;
                }
            }
            if(control==true){
                Console.WriteLine("Este Producto Con ests datos no existe");
            }
            else{
                Console.WriteLine("Editado Correctamente");
            }
            
        }
        return productos;
    }
    //-----------------------------Funciones de Editar------------------------------------
    //----------Funcion de editar el Nombre--------------------------------
    static string editarNombre(string nombreProducto){
        Console.WriteLine("ingresa el nombre nuevo:");
        string nombreNuevo=Console.ReadLine();
        nombreProducto=nombreNuevo;
        return nombreProducto;
    }
    //----------Funcion de editar la Categoría--------------------------------
    static string editarCategoria(string categoria){
        Console.WriteLine("ingresa la categoria nueva:");
        string categoriaNueva=Console.ReadLine();
        categoria=categoriaNueva;
        return categoria;
    }
    //--------------Funcion de editar el Precio--------------------------------
    static float editarPrecio(float precio){
        Console.WriteLine("ingresa el precio nuevo:");
        float precioNuevo=Convert.ToSingle(Console.ReadLine());
        precio=precioNuevo;
        return precio;
    }
    //--------------Funcion de editar la Cantidad--------------------------------
    static int editarCantidad(int cantidad){
        Console.WriteLine("ingresa la cantidad nueva:");
        int cantidadNueva=Convert.ToInt32(Console.ReadLine());
        cantidad=cantidadNueva;
        return cantidad;
    }
    //-------------------------------------------------Mostrar Productos----------------------------------------
    static void mostrarProductos(Producto[] productos){
        foreach(Producto producto in productos){
            if(producto.nombre!=null && producto.nombre!=""){
                Console.WriteLine("Los datos de este producto son:");
                Console.WriteLine("nombre: "+producto.nombre);
                Console.WriteLine("categoria: "+producto.categoria);
                Console.WriteLine("precio: "+producto.precio);
                Console.WriteLine("cantidad: "+producto.cantidad);
                Console.WriteLine("_____________________________");
            }
        }
    }
    //------------------------------------------------Mostrar Productos de Categoria------------------------------
    static void mostrarPorCategoria(Producto[] productos){
        bool control=true;
        while(control){
            Console.WriteLine("Ingresa la categoria del Producto");
            string categoriaEliger=Console.ReadLine();
            foreach(Producto producto in productos){
                if(producto.categoria==categoriaEliger){
                    Console.WriteLine("Los datos de este Producto son:");
                    Console.WriteLine("nombre: "+producto.nombre);
                    Console.WriteLine("categoria: "+producto.categoria);
                    Console.WriteLine("precio: "+producto.precio);
                    Console.WriteLine("cantidad: "+producto.cantidad);
                    Console.WriteLine("_____________________________");
                    control=false;
                }
            }
            if(control==true){
                Console.WriteLine("No hay Productos de esta categoria");
            }
        }
        
    }
}


