using System;

namespace GLM
{
    public class Vector4{
        public float x;
        public float y;
        public float z;
        public float w;
        public Vector4():this(0.0f){

        }
        public Vector4(float amt){
            this.x = this.y = this.z = amt;
            this.w = amt;
        }

        public Vector4(float x, float y, float z, float w){
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4(Vector4 other){
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
            this.w = other.w;
        }

        public override string ToString(){
            return $"({this.x}, {this.y}, {this.z}, {this.w}";
        }
    }
}