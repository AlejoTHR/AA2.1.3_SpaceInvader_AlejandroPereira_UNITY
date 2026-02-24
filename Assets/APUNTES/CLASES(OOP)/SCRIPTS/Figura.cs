///         using UnityEngine;
///         
///         
///         public class Test : MonoBehaviour
///         {
///         
///             Figura figura = new Cuadrado();
///         
///         }
///         
///         
///         public class Figura : Test
///         {
///         
///             protected Vector3 Position;
///         
///             //public abstract float Area();
///         
///             //public abstract float Perimeter();
///         
///         
///         
///         
///         }
///         
///         public class Cuadrado : Figura
///         {
///         
///         
///             protected float Base = 10;
///         
///             public override float Area()
///             {
///                 return Base*Base;
///             }
///         
///             public override float Perimeter()
///             {
///                 return Base+4;
///             }
///         
///         
///         }
///         
///         public class Rectangulo : Cuadrado
///         {
///             protected float height = 5;
///         
///             public override float Area()
///             {
///                 return Base * height;
///             }
///         
///         
///         }


