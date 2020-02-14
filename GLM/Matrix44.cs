using System;

namespace GLM
{

    public class Matrix44{
        static private int SIZE = 16;
        public  float[] m = new float[SIZE];
        public Matrix44():this(0){

        }

        public Matrix44(float amt){
            for (var i = 0; i < SIZE; i++){
                this.m[i] = 0.0f;
            }
            this.m[0] = amt;
            this.m[5] = amt;
            this.m[10] = amt;
            this.m[15] = amt;
        }

        public Matrix44(float a, float b, float c, float d,
        float e, float f, float g, float h,
        float i, float j, float k, float l,
        float m, float n, float o, float p)
        {
            this.m[0] = a;
            this.m[1] = b;
            this.m[2] = c;
            this.m[3] = d;
            this.m[4] = e;
            this.m[5] = f;
            this.m[6] = g;
            this.m[7] = h;
            this.m[8] = i;
            this.m[9] = j;
            this.m[10] = k;
            this.m[11] = l;
            this.m[12] = m;
            this.m[13] = n;
            this.m[14] = o;
            this.m[15] = p;
        }

        public Matrix44(Vector4 a, Vector4 b, Vector4 c, Vector4 d){
            this.m[0] = a.x;
            this.m[1] = a.y;
            this.m[2] = a.z;
            this.m[3] = a.w;
            this.m[4] = b.x;
            this.m[5] = b.y;
            this.m[6] = b.z;
            this.m[7] = b.w;
            this.m[8] = c.x;
            this.m[9] = c.y;
            this.m[10] = c.z;
            this.m[11] = c.w;
            this.m[12] = d.x;
            this.m[13] = d.y;
            this.m[14] = d.z;
            this.m[15] = d.w;
        }

        public Matrix44(Matrix44 other){
            for (var i = 0; i < 16; i++){
                this.m[i] = other.m[i];
            }
        }
         /*public void Identity (){
            for (var i = 0; i < SIZE; i++){
                this.m[i] = 0.0f;
            }
            this.m[0] = 1.0f;
            this.m[5] = 1.0f;
            this.m[10] = 1.0f;
            this.m[15] = 1.0f;
        }
*/
         public Matrix44 Identity (){
             Matrix44 matrix = new Matrix44(0.0f);

            for (var i = 0; i < SIZE; i++){
                matrix.m[i] = 0.0f;
            }
            matrix.m[0] = 1.0f;
            matrix.m[5] = 1.0f;
            matrix.m[10] = 1.0f;
            matrix.m[15] = 1.0f;
            return (matrix);
        }

         public Matrix44 Zero (){
             Matrix44 matrix = new Matrix44(0.0f);

            for (var i = 0; i < SIZE; i++){
                matrix.m[i] = 0.0f;
            }
            return (matrix);
        }
        public float Determinant()
        {
            Matrix44 mm = new Matrix44(this);
            float value;

            value = mm.m[12] * mm.m[9] * mm.m[6] * mm.m[3] -
            mm.m[8] * mm.m[13] * mm.m[6] * mm.m[3] -
            mm.m[12] * mm.m[5] * mm.m[10] * mm.m[3] +
            mm.m[4] * mm.m[13] * mm.m[10] * mm.m[3] +
            mm.m[8] * mm.m[5] * mm.m[14] * mm.m[3] -
            mm.m[4] * mm.m[9] * mm.m[14] * mm.m[3] -
            mm.m[12] * mm.m[9] * mm.m[2] * mm.m[7] +
            mm.m[8] * mm.m[13] * mm.m[2] * mm.m[7] +
            mm.m[12] * mm.m[1] * mm.m[10] * mm.m[7] -
            mm.m[0] * mm.m[13] * mm.m[10] * mm.m[7] -
            mm.m[8] * mm.m[1] * mm.m[14] * mm.m[7] +
            mm.m[0] * mm.m[9] * mm.m[14] * mm.m[7] +
            mm.m[12] * mm.m[5] * mm.m[2] * mm.m[11] -
            mm.m[4] * mm.m[13] * mm.m[2] * mm.m[11] -
            mm.m[12] * mm.m[1] * mm.m[6] * mm.m[11] +
            mm.m[0] * mm.m[13] * mm.m[6] * mm.m[11] +
            mm.m[4] * mm.m[1] * mm.m[14] * mm.m[11] -
            mm.m[0] * mm.m[5] * mm.m[14] * mm.m[11] -
            mm.m[8] * mm.m[5] * mm.m[2] * mm.m[15] +
            mm.m[4] * mm.m[9] * mm.m[2] * mm.m[15] +
            mm.m[8] * mm.m[1] * mm.m[6] * mm.m[15] -
            mm.m[0] * mm.m[9] * mm.m[6] * mm.m[15] -
            mm.m[4] * mm.m[1] * mm.m[10] * mm.m[15] +
            mm.m[0] * mm.m[5] * mm.m[10] * mm.m[15];
            return (value);
        }

        public  Matrix44 Inverse(){
            Matrix44 mm = new Matrix44(this);
            float det = mm.Determinant();
            
            if (det == 0.0f){
                Console.WriteLine("WARNING. matrix has no determinant, can not invert");
                return (mm);
            }
            float inv_det = 1.0f / det;
            Vector4[] v = new Vector4[4];

                    
            v[0] =  new Vector4(inv_det * ( mm.m[9] * mm.m[14] * mm.m[7] - mm.m[13] * mm.m[10] * mm.m[7] +
                                        mm.m[13] * mm.m[6] * mm.m[11] - mm.m[5] * mm.m[14] * mm.m[11] -
                                        mm.m[9] * mm.m[6] * mm.m[15] + mm.m[5] * mm.m[10] * mm.m[15] ),
                inv_det * ( mm.m[13] * mm.m[10] * mm.m[3] - mm.m[9] * mm.m[14] * mm.m[3] -
                                        mm.m[13] * mm.m[2] * mm.m[11] + mm.m[1] * mm.m[14] * mm.m[11] +
                                        mm.m[9] * mm.m[2] * mm.m[15] - mm.m[1] * mm.m[10] * mm.m[15] ),
                inv_det * ( mm.m[5] * mm.m[14] * mm.m[3] - mm.m[13] * mm.m[6] * mm.m[3] +
                                        mm.m[13] * mm.m[2] * mm.m[7] - mm.m[1] * mm.m[14] * mm.m[7] -
                                        mm.m[5] * mm.m[2] * mm.m[15] + mm.m[1] * mm.m[6] * mm.m[15] ),
                inv_det * ( mm.m[9] * mm.m[6] * mm.m[3] - mm.m[5] * mm.m[10] * mm.m[3] -
                                        mm.m[9] * mm.m[2] * mm.m[7] + mm.m[1] * mm.m[10] * mm.m[7] +
                                        mm.m[5] * mm.m[2] * mm.m[11] - mm.m[1] * mm.m[6] * mm.m[11] ));
            v[1] = new Vector4(inv_det * ( mm.m[12] * mm.m[10] * mm.m[7] - mm.m[8] * mm.m[14] * mm.m[7] -
                                        mm.m[12] * mm.m[6] * mm.m[11] + mm.m[4] * mm.m[14] * mm.m[11] +
                                        mm.m[8] * mm.m[6] * mm.m[15] - mm.m[4] * mm.m[10] * mm.m[15] ),
                inv_det * ( mm.m[8] * mm.m[14] * mm.m[3] - mm.m[12] * mm.m[10] * mm.m[3] +
                                        mm.m[12] * mm.m[2] * mm.m[11] - mm.m[0] * mm.m[14] * mm.m[11] -
                                        mm.m[8] * mm.m[2] * mm.m[15] + mm.m[0] * mm.m[10] * mm.m[15] ),
                inv_det * ( mm.m[12] * mm.m[6] * mm.m[3] - mm.m[4] * mm.m[14] * mm.m[3] -
                                        mm.m[12] * mm.m[2] * mm.m[7] + mm.m[0] * mm.m[14] * mm.m[7] +
                                        mm.m[4] * mm.m[2] * mm.m[15] - mm.m[0] * mm.m[6] * mm.m[15] ),
                inv_det * ( mm.m[4] * mm.m[10] * mm.m[3] - mm.m[8] * mm.m[6] * mm.m[3] +
                                        mm.m[8] * mm.m[2] * mm.m[7] - mm.m[0] * mm.m[10] * mm.m[7] -
                                        mm.m[4] * mm.m[2] * mm.m[11] + mm.m[0] * mm.m[6] * mm.m[11] ));
            v[2] = new Vector4(inv_det * ( mm.m[8] * mm.m[13] * mm.m[7] - mm.m[12] * mm.m[9] * mm.m[7] +
                                        mm.m[12] * mm.m[5] * mm.m[11] - mm.m[4] * mm.m[13] * mm.m[11] -
                                        mm.m[8] * mm.m[5] * mm.m[15] + mm.m[4] * mm.m[9] * mm.m[15] ),
                inv_det * ( mm.m[12] * mm.m[9] * mm.m[3] - mm.m[8] * mm.m[13] * mm.m[3] -
                                        mm.m[12] * mm.m[1] * mm.m[11] + mm.m[0] * mm.m[13] * mm.m[11] +
                                        mm.m[8] * mm.m[1] * mm.m[15] - mm.m[0] * mm.m[9] * mm.m[15] ),
                inv_det * ( mm.m[4] * mm.m[13] * mm.m[3] - mm.m[12] * mm.m[5] * mm.m[3] +
                                        mm.m[12] * mm.m[1] * mm.m[7] - mm.m[0] * mm.m[13] * mm.m[7] -
                                        mm.m[4] * mm.m[1] * mm.m[15] + mm.m[0] * mm.m[5] * mm.m[15] ),
                inv_det * ( mm.m[8] * mm.m[5] * mm.m[3] - mm.m[4] * mm.m[9] * mm.m[3] -
                                        mm.m[8] * mm.m[1] * mm.m[7] + mm.m[0] * mm.m[9] * mm.m[7] +
                                        mm.m[4] * mm.m[1] * mm.m[11] - mm.m[0] * mm.m[5] * mm.m[11] ));
            v[3] = new Vector4(	inv_det * ( mm.m[12] * mm.m[9] * mm.m[6] - mm.m[8] * mm.m[13] * mm.m[6] -
                                        mm.m[12] * mm.m[5] * mm.m[10] + mm.m[4] * mm.m[13] * mm.m[10] +
                                        mm.m[8] * mm.m[5] * mm.m[14] - mm.m[4] * mm.m[9] * mm.m[14] ),
                inv_det * ( mm.m[8] * mm.m[13] * mm.m[2] - mm.m[12] * mm.m[9] * mm.m[2] +
                                        mm.m[12] * mm.m[1] * mm.m[10] - mm.m[0] * mm.m[13] * mm.m[10] -
                                        mm.m[8] * mm.m[1] * mm.m[14] + mm.m[0] * mm.m[9] * mm.m[14] ),
                inv_det * ( mm.m[12] * mm.m[5] * mm.m[2] - mm.m[4] * mm.m[13] * mm.m[2] -
                                        mm.m[12] * mm.m[1] * mm.m[6] + mm.m[0] * mm.m[13] * mm.m[6] +
                                        mm.m[4] * mm.m[1] * mm.m[14] - mm.m[0] * mm.m[5] * mm.m[14] ),
                inv_det * ( mm.m[4] * mm.m[9] * mm.m[2] - mm.m[8] * mm.m[5] * mm.m[2] +
                                        mm.m[8] * mm.m[1] * mm.m[6] - mm.m[0] * mm.m[9] * mm.m[6] -
                                        mm.m[4] * mm.m[1] * mm.m[10] + mm.m[0] * mm.m[5] * mm.m[10] ) );

                return (new Matrix44(v[0], v[1], v[2], v[3]));
        }

        public  Matrix44 Tranpose(){
            Matrix44 mm = new Matrix44(this);
            Vector4[] v = new Vector4[4];

            v[0] = new Vector4(mm.m[0], mm.m[4], mm.m[8], mm.m[12]);
            v[1] = new Vector4(mm.m[1], mm.m[5], mm.m[9], mm.m[13]);
            v[2] = new Vector4(mm.m[2], mm.m[6], mm.m[10], mm.m[14]);
            v[3] = new Vector4(mm.m[3], mm.m[7], mm.m[11], mm.m[15]);
            return (new Matrix44(v[0], v[1], v[2], v[3]));
        }

        public static Vector4 operator *(Matrix44 m, Vector4 rhs){
            Vector4  res = new Vector4();
        
            res.x = m.m[0] * rhs.x + m.m[4] * rhs.y + m.m[8] * rhs.z + m.m[12] * rhs.w;
            res.y = m.m[1] * rhs.x + m.m[5] * rhs.y + m.m[9] * rhs.z + m.m[13] * rhs.w;
            res.z = m.m[2] * rhs.x + m.m[6] * rhs.y + m.m[10] * rhs.z + m.m[14] * rhs.w;
            res.w = m.m[3] * rhs.x + m.m[7] * rhs.y + m.m[11] * rhs.z + m.m[15] * rhs.w;
            return (res);
        }
        public static Matrix44 operator *(Matrix44 m, Matrix44 rhs){
            Matrix44  res = new Matrix44(0.0f);
            int       index;

            index = 0;
            for (var col = 0; col < 4; col ++){
                for (var row = 0; row < 4; row ++){
                    float sum = 0.0f;
                    for (var i = 0; i < 4; i++){
                        sum += (rhs.m[i + col * 4] * m.m[row + i *4]);
                    }
                    res.m[index] = sum;
                    index++;
                }
            }
            return (res);
        }

        public  Matrix44 Translate(Vector3 dt){
            Matrix44 matrix = new Matrix44(this);
            Matrix44 tmp = new Matrix44(1.0f);

          
            tmp.m[12] = dt.x;
            tmp.m[13] = dt.y;
            tmp.m[14] = dt.z;
            return (tmp * matrix);
        }

        public  Matrix44 Translate(float dt){
            Matrix44 matrix = new Matrix44(this);
            Matrix44 tmp = new Matrix44(1.0f);

            tmp.m[12] = dt;
            tmp.m[13] = dt;
            tmp.m[14] = dt;
            return (tmp * matrix);
        }

        public  Matrix44 RotateX(float rad){
            Matrix44 matrix = new Matrix44(this);
            Matrix44 tmp = new Matrix44(1.0f);

            tmp.m[5] = (float)Math.Cos(rad);
            tmp.m[9] = -(float)Math.Sin(rad);
            tmp.m[6] = (float)Math.Sin(rad);
            tmp.m[10] = (float)Math.Cos(rad);
            return (tmp * matrix);
        }

        public  Matrix44 RotateY(float rad){
            Matrix44 matrix = new Matrix44(this);
            Matrix44 tmp = new Matrix44(1.0f);

            tmp.m[0] = (float)Math.Cos(rad);
            tmp.m[8] = (float)Math.Sin(rad);
            tmp.m[2] = -(float)Math.Sin(rad);
            tmp.m[10] = (float)Math.Cos(rad);

            return (tmp * matrix);
        }

        public  Matrix44 RotateZ(float rad){
            Matrix44 matrix = new Matrix44(this);
            Matrix44 tmp = new Matrix44(1.0f);

            tmp.m[0] = (float)Math.Cos(rad);
            tmp.m[1] = -(float)Math.Sin(rad);
            tmp.m[4] = (float)Math.Sin(rad);
            tmp.m[5] = (float)Math.Cos(rad);
            return (tmp * matrix);
        }

        public Matrix44 Scale(Vector3 dt){
            Matrix44 matrix = new Matrix44(this);
            Matrix44 tmp = new Matrix44(1.0f);

            tmp.m[0] = dt.x;
            tmp.m[5] = dt.y;
            tmp.m[10] = dt.z;
            return (tmp * matrix);
        }
        
        public  Matrix44 Scale(float dt){
            Matrix44 matrix = new Matrix44(this);
            Matrix44 tmp = new Matrix44(1.0f);

            tmp.m[0] = dt;
            tmp.m[5] = dt;
            tmp.m[10] = dt;
            return (tmp * matrix);
        }

        public static Matrix44 FromQuaternion(Versor q){
            float w = q.x;
            float x = q.y;
            float y = q.z;
            float z = q.w;

            Vector4[] v = new Vector4[4];
            
            v[0] = new Vector4(1.0f - 2.0f * y * y - 2.0f * z * z,
            2.0f * x * y + 2.0f * w * z, 2.0f * x * z - 2.0f * w * y, 0.0f);
            v[1] = new Vector4(2.0f * x * y - 2.0f * w * z,
            1.0f - 2.0f * x * x - 2.0f * z * z, 2.0f * y * z + 2.0f * w * x, 0.0f);
            v[2] = new Vector4(2.0f * x * z + 2.0f * w * y, 2.0f * y * z - 2.0f * w * x,
            1.0f - 2.0f * x * x - 2.0f * y * y, 0.0f);
            v[3] = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
	        return (new Matrix44(v[0], v[1], v[2], v[3]));
        }

        public static Matrix44 LookAt(Vector3 eye, Vector3 at, Vector3 Wordl_Up){
            //Forward fd, Left lt, up, Vector (normailzed)
            Vector3 fd = eye - at;
            fd = fd.Normalize();
            Vector3 lt = Wordl_Up.Cross( fd);
            lt = lt.Normalize();
            Vector3 up = fd.Cross(lt);

            //Identity !
            Matrix44 matrix = new  Matrix44(1.0f);

            //Rotation
            matrix.m[0] = lt.x;
            matrix.m[4] = lt.y;
            matrix.m[8] = lt.z;
            matrix.m[1] = up.x;
            matrix.m[5] = up.y;
            matrix.m[9] = up.z;
            matrix.m[2] = fd.x;
            matrix.m[6] = fd.y;
            matrix.m[10]= fd.z;

            //Translation
            matrix.m[12]= -lt.x * eye.x - lt.y * eye.y - lt.z * eye.z;
            matrix.m[13]= -up.x * eye.x - up.y * eye.y - up.z * eye.z;
            matrix.m[14]= -fd.x * eye.x - fd.y * eye.y - fd.z * eye.z;

            return (matrix);
        }

        public Matrix44 Perspective(float fovy, float aspect, float near, float far){
            float inverse_range = 1.0f / (float)Math.Tan(fovy / 2.0f);
            float sx = inverse_range / aspect;
            float sy = inverse_range;
            float sz = -(far + near) / (far - near);
            float pz = -(2.0f * far * near) / (far - near);

            Matrix44 matrix = new Matrix44(1.0f);

            matrix.m[0] = sx;
            matrix.m[5] = sy;
            matrix.m[10] = sz;
            matrix.m[14] = pz;
            matrix.m[11] = -1.0f;
            return (matrix);
        }

        public Matrix44 Rotate(Matrix44 matrix, float angle, Vector3 axis){
            axis = axis.Normalize();
            float s = (float)Math.Sin(angle);
            float c = (float)Math.Cos(angle);
            float oc = 1.0f - c;

            Vector4[] v = new Vector4[4];
            Matrix44  tmp = new Matrix44(1.0f);
            v[0] = new Vector4(oc * axis.x * axis.x + c,
	        oc * axis.x * axis.y - axis.z * s,
	        oc * axis.z * axis.x + axis.y * s,  0.0f);
	        v[1] = new Vector4(oc * axis.x * axis.y + axis.z * s,
	        oc * axis.y * axis.y + c,
            oc * axis.y * axis.z - axis.x * s,  0.0f);
            v[2] = new Vector4(oc * axis.z * axis.x - axis.y * s,
            oc * axis.y * axis.z + axis.x * s,
            oc * axis.z * axis.z + c,0.0f);
            tmp = new Matrix44(v[0], v[1], v[2], new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
            return (tmp * matrix);
        }
    }
}
