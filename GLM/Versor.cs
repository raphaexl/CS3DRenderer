using System;

namespace GLM{
    public class Versor{
        public float x;
        public float y;
        public float z;

        public float w;

        public Versor():this(0.0f){

        }
        public Versor(float amt){
            this.x = this.y = this.z = this.w = amt;
        }

        public Versor(float x, float y, float z, float w){
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Versor(Versor other){
            this.x = other.x;
            this.y = other.y;
            this.z = other.z;
            this.w = other.w;
        }

        public static Versor operator -(Versor vec){
            vec.x = -vec.x;
            vec.y = -vec.y;
            vec.z = -vec.z;
            vec.w = -vec.w;
            return (vec);
        }

        public static Versor operator +(Versor vec){
            vec.x = +vec.x;
            vec.y = +vec.y;
            vec.z = +vec.z;
            vec.w = +vec.w;
            return (vec);
        }

        public static Versor operator +(Versor v1, Versor v2){
            Versor res = new Versor();

            res.x = v1.x + v2.x;
            res.y = v1.y + v2.y;
            res.z = v1.z + v2.z;
            res.w = v1.w + v2.w;
            return (res);
        }

        public static Versor operator -(Versor v1, Versor v2){
            Versor res = new Versor();

            res.x = v1.x - v2.x;
            res.y = v1.y - v2.y;
            res.z = v1.z - v2.z;
            res.w = v1.z - v2.w;
            return (res);
        }

        public static Versor operator *(Versor v1, float amt){
            Versor res = new Versor();
            
            res.x = v1.x * amt;
            res.y = v1.y * amt;
            res.z = v1.z * amt;
            res.w = v1.w * amt;
            return (res);
        }

        public static Versor operator *(float amt, Versor v2){
            Versor res = new Versor();
            
            res.x = amt * v2.x;
            res.y = amt * v2.y;
            res.z = amt * v2.z;
            res.w = amt * v2.w;
            return (res);
        }

         public static Versor operator *(Versor v1, Versor v2){
            Versor res = new Versor();
            
            res.x = v1.x * v2.x;
            res.y = v1.y * v2.y;
            res.z = v1.z * v2.z;
            res.w = v1.w * v2.w;
            return (res);
        }


        public static Versor operator /(Versor v1, float amt){
            Versor res = new Versor();
            
            res.x = v1.x / amt;
            res.y = v1.y / amt;
            res.z = v1.z / amt;
            res.w = v1.w / amt;
            return (res);
        }

        public static Versor operator /(float amt, Versor v2){
            Versor res = new Versor();
            
            res.x = amt / v2.x;
            res.y = amt / v2.y;
            res.z = amt / v2.z;
            res.w = amt / v2.w;
            return (res);
        }

        public  float Dot( Versor v2){
            Versor v1 = new Versor(this);
            return (v1.x * v2.x + v1.y * v2.y + v1.z * v2.z + v1.w * v2.w);
        }
        public Versor FromAngleAxis(float rad, float x, float y, float z){
            Versor res = new Versor();

            res.x = (float)Math.Cos(rad / 2.0f);
            res.y = (float)Math.Sin(rad / 2.0f) * x;
            res.z = (float)Math.Sin(rad / 2.0f) * y;
            res.w = (float)Math.Sin(rad / 2.0) * z;
            return (res);
        }
        public  Versor FromAngleAxis(float rad, Vector3 axis){
            Versor res = new Versor();

            res.x = (float)Math.Cos(rad / 2.0f) ;
            res.y = (float)Math.Sin(rad / 2.0f) * axis.x;
            res.z = (float)Math.Sin(rad / 2.0f) * axis.y;
            res.w = (float)Math.Sin(rad / 2.0f) * axis.z;
            return (res);
        }

        public  Versor Lerp(Versor r, float t){
            Versor q = new Versor(this);
            float cos_half_tetha = q.Dot( r);
            
            if (cos_half_tetha < 0.0f){
               q = -q;
               cos_half_tetha = q.Dot(r);
            }
            if ((float)Math.Abs(cos_half_tetha) >= 1.0f){
                return (q);
            }
            float sin_half_theta = (float)Math.Sqrt(1.0f - cos_half_tetha * cos_half_tetha);

            Versor result = new Versor();

            if (Math.Abs(sin_half_theta) < 0.0001){
                result = (1.0f - t) * q + t * r;
                return (result);
            }
            float half_tetha = (float)Math.Acos(cos_half_tetha);
            float a = (float)Math.Sin((1.0f - t) * half_tetha) / sin_half_theta;
            float b = (float)Math.Sin(t * half_tetha) / sin_half_theta;
            result = q * a + r * b;
            return (result);
        }

        public  Versor Normalize(){
            float norm1;
            float norm2;
            Versor v = new Versor(this.x, this.y, this.z, w);
            norm2 = v.x * v.x + v.y * v.y + v.z * v.z;
            if (Math.Abs(1.0f - norm2) < 1e-6f){
                return (v);
            }
            norm1 = (float)Math.Sqrt(norm2);
            v.x /= norm1;
            v.y /= norm1;
            v.z /= norm1;
            v.w /= norm1;
            return (v);
        }
    }
}