using System;

namespace Vector
{
    public  class Vector2{
        public float x;
        public float y;

        public Vector2():this(0, 0){    
        }

        public Vector2(float amount){
            this.x = this.y = amount;
        }

        public Vector2(float x, float y){
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 other){
            this.x = other.x;
            this.y = other.y;
        }

        public virtual float Norm(){
            return ((float)Math.Sqrt(this.x * this.x + this.y * this.y));
        }
    
        public virtual float Norm2(){
            return ((this.x * this.x + this.y * this.y));
        }
        
        public  Vector2 Normalize(){
           
            var norm = (float)Math.Sqrt(x * x + y * y);
            var res = new Vector2();

            if (norm == 0.0f){
                return (res);
            }
            res.x = x / norm;
            res.y = y / norm;
            return (res);
        }

        public float Dot(Vector2 v2){
            Vector2 v1 = new Vector2(this);
         return (v1.x * v2.x + v1.y * v2.y);
        }
       
         public static Vector2 operator -(Vector2 res){
            res.x = -res.x;
            res.y = -res.y;
            return (res);
        }
        public static Vector2 operator +(Vector2 res){
            res.x = +res.x;
            res.y = +res.y;
            return (res);
        }
        public static Vector2 operator +(Vector2 v1, Vector2 v2){
            Vector2 res = new Vector2();

            res.x = v1.x + v2.x;
            res.y = v1.y + v2.y;
            return (res);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2){
            Vector2 res = new Vector2();

            res.x = v1.x - v2.x;
            res.y = v1.y - v2.y;
            return (res);
        }
         public static Vector2 operator *(Vector2 v, float value){
            Vector2 res = new Vector2();

            res.x = v.x * value;
            res.y = v.y * value;
            return (res);
        }

         public static Vector2 operator *(float value, Vector2 v){
            Vector2 res = new Vector2();

            res.x = v.x * value;
            res.y = v.y * value;
            return (res);
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2){
            Vector2 res = new Vector2();

            res.x = v1.x * v2.x;
            res.y = v1.y * v2.y;
            return (res);
        }
       
        public static Vector2 operator / (Vector2 v1, float value){
            Vector2 vec = new Vector2();

            vec.x = v1.x / value;
            vec.y = v1.y / value;
            return (vec);
        }

        public static Vector2 operator / (float value, Vector2 v){
            Vector2 vec = new Vector2();

            vec.x = v.x / value;
            vec.y = v.y / value;
            return (vec);
        }

        public override string ToString()=>$"({this.x}, {this.y})";

        // For not Forget 
          #pragma warning disable
        public static Vector2 Cross(Vector2 v1, Vector2 v2){
          Vector2 res = new Vector2();

          res.x = v1.x * v2.x;
          return (res);
        }
        #pragma warning restore

        //For Learning Purpose
        public static bool operator ==(Vector2 v1, Vector2 v2){
            return (v1.Equals(v2));
        }

        public static bool operator !=(Vector2 v1, Vector2 v2){
            return (!v1.Equals(v2));
        }
        private bool IsEquals(Vector2 other)
        {
            return (other.x == this.x && this.y == other.y);
        }

        public override bool Equals(object obj){
            //If null
            if (Object.ReferenceEquals(null, obj)){
                return (false);
            }
            //Same Object
            if (Object.ReferenceEquals(this, obj)){
                return (true);
            }
            //Same Type ?
            if (this.GetType() != obj.GetType()){
                return (false);
            }

            return (IsEquals((Vector2)obj));
        }

        public bool Equals(Vector2 vec){
            if (Object.ReferenceEquals(vec, null)){
                return (false);
            }

            if (Object.ReferenceEquals(vec, this)){
                return (true);
            }
            return (IsEquals(vec));
        }

        public override int GetHashCode(){
            int a = (int)this.x;
            int b = (int)this.y;
            return (a ^ b);
        }
    }
    }