using System;

namespace GLM
{
    public class Vector3 : Vector2{
        public float z;

        public Vector3():base(0.0f){
            this.z = 0;
        }
        public Vector3(float amt):base(amt){
            this.z = amt;
        }
        public Vector3(float x, float y, float z):base(x, y){
            this.z = z;
        }

        public Vector3(Vector3 other){
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;

        }
        public override float Norm(){
            float norm2;
            norm2 = this.x * this.x + this.y * this.y + this.z * this.z;
            return ((float)Math.Sqrt(norm2));
        }

        public override float Norm2(){
            return (this.x * this.x + this.y * this.y + this.z * this.z);
        }

        new public  Vector3 Normalize(){
            Vector3 res = new Vector3();
            float norm2 = x * x + y * y + z * z;
            norm2 = (float)Math.Sqrt(norm2);
            res.x = this.x / norm2;
            res.y = this.y / norm2;
            res.z = this.z / norm2;
            return (res);
        }

        public  float Dot(Vector3 v2){
            Vector3 v1 = new Vector3(this);
            return (v1.x * v2.x + v1.y * v2.y + v1.z * v2.z);
        }

        public Vector3 Cross(Vector3 v2){
            Vector3 res = new Vector3();
            Vector3 v1 = new Vector3(this);

            res.x = v1.y * v2.z - v1.z * v2.y;
            res.y = v1.z * v2.x - v1.x * v2.z;
            res.z = v1.x * v2.y - v1.y * v2.x;
            return (res);
        }

        public static Vector3 operator -(Vector3 other){
            other.x = -other.x;
            other.y = -other.y;
            other.z = -other.z;
            return (other);
        }
            public static Vector3 operator +(Vector3 other){
            other.x = +other.x;
            other.y = +other.y;
            other.z = +other.z;
            return (other);
        }
        public static Vector3 operator +(Vector3 v1, Vector3 v2){
            Vector3 res = new Vector3();

            res.x = v1.x + v2.x;
            res.y = v1.y + v2.y;
            res.z = v1.z + v2.z;   
            return (res);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2){
            Vector3 res = new Vector3();

            res.x = v1.x - v2.x;
            res.y = v1.y - v2.y;
            res.z = v1.z = v2.z;

            return (res);
        }

        public static Vector3 operator *(Vector3 v1, float amt){
            Vector3 res = new Vector3();

            res.x = v1.x * amt;
            res.y = v1.y * amt;
            res.z = v1.z * amt;
            return (res);
        }

        public static Vector3 operator *(float amt, Vector3 v1){
            Vector3 res = new Vector3();

            res.x = v1.x * amt;
            res.y = v1.y * amt;
            res.z = v1.z * amt;
            return (res);
        }

        public static Vector3 operator *(Vector3 v1, Vector3 v2){
            Vector3 res = new Vector3();

            res.x = v1.x * v2.x;
            res.y = v1.y * v2.y;
            res.z = v1.z * v2.z;
            return (res);
        }

        public static Vector3 operator / (Vector3 v, float amt){
            Vector3 res = new Vector3();

            res.x = v.x / amt;
            res.y = v.y / amt;
            res.z = v.z / amt;
            return (res);
        }

        public static Vector3 operator / (float amt, Vector3 v){
            Vector3 res = new Vector3();

            res.x = v.x / amt;
            res.y = v.y / amt;
            res.z = v.z / amt;
            return (res);
        }

        public override string ToString() => $"({this.x}, {this.y}, {this.z})";

        //As In mother class

        public static bool operator ==(Vector3 v1, Vector3 v2){
            return (v1.Equals(v2));
        }
        public static bool operator !=(Vector3 v1, Vector3 v2){
            return (!v1.Equals(v2));
        } 
        private bool IsEqual(Vector3 vec){
            return (vec.x == this.x && vec.y == this.y && vec.z == this.z);
        }
        public override bool Equals(object obj){
            if (Object.ReferenceEquals(obj, null)){
                return (false);
            }
            if (Object.ReferenceEquals(obj, this)){
                return (true);
            }
            if (obj.GetType() != this.GetType()){
                return (false);
            }
            return (IsEqual((Vector3)obj));
        }

        public bool Equals(Vector3 value){
            if (Object.ReferenceEquals(null, value)){
                return (false);
            }
            if (Object.ReferenceEquals(this, value)){
                return (true);
            }
            return IsEqual(value);
        }

        
        public override int GetHashCode(){
            int a = (int)this.x;
            int b = (int)this.y;
            int c = (int)this.z;
            return (a ^ b ^ c);
        }
    }
}