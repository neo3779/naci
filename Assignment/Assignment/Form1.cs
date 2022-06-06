using System;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;

namespace Assignment
{
    ////////////////////////
    ///Struct for a plane///
    ////////////////////////

    public struct Plane
    {
        //Data reltive to plane
        private Color colour;
        private int destination;
        private int speed;

        //Constructor
        public Plane(Color c, int d, int s)
        {
            this.colour = c;
            this.destination = d;
            this.speed = s;
        }

        //Colour get/set
        public Color Colour
        {
            get {return colour;}
            set {colour = value;}
        }

        //Destination get/set
        public int Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        //Speed get/set
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }

    public partial class frm : Form
    {
        //Planes
        private Plane pld, pl0, pl1, pl2, pl3, pl4, pl5, pl6, pl7, pl8, pl9;
        //Semaphores
        private Semaphore semaphore0, semaphore1, semaphore2, semaphore3, semaphore4, semaphore5, semaphore6, semaphore7, semaphore8;
        //Buffer
        private Buffer buffer0, buffer1, buffer2, buffer3, buffer4, buffer5, buffer6, buffer7, buffer8, buffer9, buffer10, buffer11, buffer12,buffer13,buffer14,buffer15,buffer16,buffer17,buffer18;
        //Thread
        private Thread semThread0, semThread1, semThread2, semThread3, semThread4, semThread5, semThread6, semThread7, semThread8;
        private Thread buffThread0, buffThread1, buffThread2, buffThread3, buffThread4, buffThread5, buffThread6, buffThread7, buffThread8, buffThread9, buffThread10, buffThread11, buffThread12, buffThread13, buffThread14, buffThread15, buffThread16, buffThread17, buffThread18;
        private Thread thread0, thread1, thread2, thread3, thread4, thread5, thread6, thread7,thread8, thread9;
        //Sections
        private StraightThrough  p6,p8;
        private Junction p4, p5,p7;
        private RunWay p9;
        private ArrivalRunWay p3;
        private HubSection p0, p1, p2;


        public frm()
        {
            InitializeComponent();

            //Planes
            pld = new Plane(Color.LightGreen, 0, 0);
            pl0 = new Plane(Color.Blue, 0, 50);
            pl1 = new Plane(Color.Red, 0, 50);
            pl2 = new Plane(Color.Yellow, 0, 50);
            pl3 = new Plane(Color.Green, 0, 50);
            pl4 = new Plane(Color.White, 0, 50);
            pl5 = new Plane(Color.Black, 0, 50);
            pl6 = new Plane(Color.Brown, 0, 50);
            pl7 = new Plane(Color.Orange, 0, 50);
            pl8 = new Plane(Color.Purple, 0, 50);
            pl9 = new Plane(Color.Gray, 0, 50);
           
            //Semaphores
            semaphore0 = new Semaphore();
            semaphore1 = new Semaphore();
            semaphore2 = new Semaphore();
            semaphore3 = new Semaphore();
            semaphore4 = new Semaphore();
            semaphore5 = new Semaphore();
            semaphore6 = new Semaphore();
            semaphore7 = new Semaphore();
            semaphore8 = new Semaphore();

            //Buffers
            buffer0 = new Buffer();
            buffer1 = new Buffer();
            buffer2 = new Buffer();
            buffer3 = new Buffer();
            buffer4 = new Buffer();
            buffer5 = new Buffer();
            buffer6 = new Buffer();
            buffer7 = new Buffer();
            buffer8 = new Buffer();
            buffer9 = new Buffer();
            buffer10 = new Buffer();
            buffer11 = new Buffer();
            buffer12 = new Buffer();
            buffer13 = new Buffer();
            buffer14 = new Buffer();
            buffer15 = new Buffer();
            buffer16 = new Buffer();
            buffer17 = new Buffer();
            buffer18 = new Buffer();

            //Sections
            p0 = new HubSection (2, sec0, semaphore8,semaphore0,buffer10,buffer0,but0,ref pl0);
            p1 = new HubSection(2, sec1,semaphore6,semaphore1,buffer11,buffer1,but1,ref pl1);
            p2 = new HubSection(2, sec2,semaphore7,semaphore2,buffer12,buffer2,but2,ref pl2);
            p3 = new ArrivalRunWay(2, sec3, semaphore5, semaphore4, buffer6, buffer7, buffer8, buffer9, buffer13, buffer14, buffer15, buffer16, buffer17, buffer18, buffer4, ref pl3, but3, rad0, rad1, rad2, rad3);
            p4 = new Junction(1,sec4,buffer0,buffer1,buffer11,semaphore0,semaphore1,semaphore6,2,ref pld);
            p5 = new Junction(1, sec5,buffer1,buffer2,buffer12,semaphore1,semaphore2,semaphore7,3,ref pld);
            p6 = new StraightThrough(1, sec6,semaphore2,semaphore3,buffer2,buffer3,ref pld);
            p7 = new Junction(4, sec7, buffer5, buffer0, buffer10, semaphore5, semaphore0, semaphore8, 1, ref pld);
            p8 = new StraightThrough(2, sec8,semaphore3,semaphore4,buffer3,buffer4, ref pld);
            p9 = new RunWay(3, sec9, semaphore4, semaphore5, buffer4, buffer5, buffer6, buffer7, buffer8, buffer9, buffer13, buffer14, buffer15, buffer16, buffer17, buffer18, ref pld);

            //Semaphore threads
            semThread0 = new Thread(new ThreadStart(semaphore0.Start));
            semThread1 = new Thread(new ThreadStart(semaphore1.Start));
            semThread2 = new Thread(new ThreadStart(semaphore2.Start));
            semThread3 = new Thread(new ThreadStart(semaphore3.Start));
            semThread4 = new Thread(new ThreadStart(semaphore4.Start));
            semThread5 = new Thread(new ThreadStart(semaphore5.Start));
            semThread6 = new Thread(new ThreadStart(semaphore6.Start));
            semThread7 = new Thread(new ThreadStart(semaphore7.Start));
            semThread8 = new Thread(new ThreadStart(semaphore8.Start));

            //Buffer threads
            buffThread0 = new Thread(new ThreadStart(buffer0.Start));
            buffThread1 = new Thread(new ThreadStart(buffer1.Start));
            buffThread2 = new Thread(new ThreadStart(buffer2.Start));
            buffThread3 = new Thread(new ThreadStart(buffer3.Start));
            buffThread4 = new Thread(new ThreadStart(buffer4.Start));
            buffThread5 = new Thread(new ThreadStart(buffer5.Start));
            buffThread6 = new Thread(new ThreadStart(buffer6.Start));
            buffThread7 = new Thread(new ThreadStart(buffer7.Start));
            buffThread8 = new Thread(new ThreadStart(buffer8.Start));
            buffThread9 = new Thread(new ThreadStart(buffer9.Start));
            buffThread10 = new Thread(new ThreadStart(buffer10.Start));
            buffThread11 = new Thread(new ThreadStart(buffer11.Start));
            buffThread12 = new Thread(new ThreadStart(buffer12.Start));
            buffThread13 = new Thread(new ThreadStart(buffer12.Start));
            buffThread14 = new Thread(new ThreadStart(buffer12.Start));
            buffThread15 = new Thread(new ThreadStart(buffer12.Start));
            buffThread16 = new Thread(new ThreadStart(buffer12.Start));
            buffThread17 = new Thread(new ThreadStart(buffer12.Start));
            buffThread18 = new Thread(new ThreadStart(buffer12.Start));

            //Section threads
            thread0 = new Thread(new ThreadStart(p0.Start));
            thread1 = new Thread(new ThreadStart(p1.Start));
            thread2 = new Thread(new ThreadStart(p2.Start));
            thread3 = new Thread(new ThreadStart(p3.Start));
            thread4 = new Thread(new ThreadStart(p4.Start));
            thread5 = new Thread(new ThreadStart(p5.Start));
            thread6 = new Thread(new ThreadStart(p6.Start));
            thread7 = new Thread(new ThreadStart(p7.Start));
            thread8 = new Thread(new ThreadStart(p8.Start));
            thread9 = new Thread(new ThreadStart(p9.Start));

            //Start all the threads
            semThread0.Start();
            semThread1.Start();
            semThread2.Start();
            semThread3.Start();
            semThread4.Start();
            semThread5.Start();
            semThread6.Start();
            semThread7.Start();
            semThread8.Start();
            
            buffThread0.Start();
            buffThread1.Start();
            buffThread2.Start();
            buffThread3.Start();
            buffThread4.Start();
            buffThread5.Start();
            buffThread6.Start();
            buffThread7.Start();
            buffThread8.Start();
            buffThread9.Start();
            buffThread10.Start();
            buffThread11.Start();
            buffThread12.Start();
            buffThread13.Start();
            buffThread14.Start();
            buffThread15.Start();
            buffThread16.Start();
            buffThread17.Start();
            buffThread18.Start();
            
            thread0.Start();
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();
            thread7.Start();
            thread8.Start();
            thread9.Start();

            buffer13.Write(pl4);
            buffer14.Write(pl5);
            buffer15.Write(pl6);
            buffer16.Write(pl7);
            buffer17.Write(pl8);
            buffer18.Write(pl9);


            //Cancel all the threads to close the application
            this.Closing += new CancelEventHandler(this.frm_Closing);
        }

        private void frm_Closing(object sender, CancelEventArgs e)
        {
            // Kill off all threads on exit.
            Environment.Exit(Environment.ExitCode);
        }

        //////////
        //BUFFER//
        //////////

        public class Buffer
        {
            //Buffer data
            private Plane plane;
            private bool empty = true;

            //Empty get/set
            public bool Empty
            {
                get { return empty; }
            }
            
            //PlaneInfo get/set
            public Plane PlaneInfo
            {
                get { return plane; }
            }

            //Read plane information in to the buffer if the buffer is empty
            public void Read(ref Plane plane)
            {
                lock (this)
                {
                    // Check whether the buffer is empty.
                    if (empty)
                        Monitor.Wait(this);
                    empty = true;
                    plane = this.plane;
                    Monitor.Pulse(this);
                }
            }

            //Write the plane information out of the buffer
            public void Write(Plane plane)
            {
                lock (this)
                {
                    // Check whether the buffer is full.
                    if (!empty)
                        Monitor.Wait(this);
                    empty = false;
                    this.plane = plane;
                    Monitor.Pulse(this);
                }
            }

            public void Start()
            {
            }

        }// end class Buffer
        
        /////////////
        //SEMAPHORE//
        /////////////
        
        public class Semaphore
        {
            private int count = 0;

            //Wait for the semphore to signal
            public void Wait()
            {
                lock (this)
                {
                    if (count == 0)
                        Monitor.Wait(this);
                    count = 0;
                }
            }

            //Signal the semphore
            public void Signal()
            {
                lock (this)
                {
                    count = 1;
                    Monitor.Pulse(this);
                }
            }

            public void Start()
            {
            }

        }// end class Semaphore

        /////////////////
        ///Plane Panel///
        /////////////////

        public abstract class PlanePanel
        {
            public Panel panel;
            public int direction;
            public Plane planeInfo;
            public Point plane;
            public int xDelta = 10;
            public int yDelta = 10;

            //method start must be implermented for ever other panel
            public abstract void Start();

            // set the plane to the zero postion dependent of the panel line
            public void zeroPlane()
            {
                if (direction == 1 || direction == 2)
                {
                    //top right
                    plane.X = 10;
                    plane.Y = 10;
                }
                else
                {   
                    //bottom left
                    plane.X = panel.Width - 20;
                    plane.Y = panel.Height - 20;
                }
                
            }

            //move the plane in a given direction
            public void movePlane(int xDelta, int yDelta)
            {
                //move plane dependent on the direction value
                switch (direction)
                {
                    case 1:
                        //move right
                        plane.X += xDelta;
                        break;
                    case 2:
                        // move down
                        plane.Y += yDelta;
                        break;
                    case 3:
                        // move left
                        plane.X -= xDelta;
                        break;
                    case 4:
                        //move up
                        plane.Y -= yDelta;
                        break;
                    default:
                        break;
                }
            }

            // switch the driection that the plane was going in to the oppsite
            protected void switchDirection()
            {
                //change the direction to the oppsite direction
                switch (direction)
                {
                    case 1:
                        //move left
                        direction = 3;
                        break;
                    case 2:
                        // move up
                        direction = 4;
                        break;
                    case 3:
                        //move right
                        direction = 1;
                        break;
                    case 4:
                        //move dowm
                        direction = 2;
                        break;
                    default:
                        break;
                }
            }

            //draw the plane
            public void panel_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;

                SolidBrush brush = new SolidBrush(planeInfo.Colour);
                g.FillRectangle(brush, plane.X, plane.Y, 10, 10);
                //Dispose graphics resources
                brush.Dispose();     
                g.Dispose();         
            }

        }//end class Plane Panel Class
        
        ////////////////////
        //Straight Through//
        ////////////////////

        public class StraightThrough : PlanePanel
        {
            private Semaphore inSemaphore;
            private Semaphore outSemaphore;
            private Buffer inBuffer,outBuffer;
            private bool exit;
            
            //constructor
            public StraightThrough(int direction,
                               Panel panel,
                               Semaphore inSemaphore,
                               Semaphore outSemaphore,
                               Buffer inBuffer, Buffer outBuffer,
                               ref Plane planeInfo)
            {
                this.direction = direction;
                this.panel = panel;
                this.panel.Paint += new PaintEventHandler(this.panel_Paint);
                this.inSemaphore = inSemaphore;
                this.outSemaphore = outSemaphore;
                this.inBuffer = inBuffer;
                this.outBuffer = outBuffer;
                this.planeInfo = planeInfo;
                this.exit = true;
                this.zeroPlane();
            }

            public override void Start()
            {
                //find the length of the panel
                int length = 0;
                if (direction == 2 || direction == 4)
                    length = (panel.Height - 30) / 10;
                else
                    length = (panel.Width - 30) / 10;

                panel.BackColor = Color.LightGreen;
                
                // loop through to read in, draw/move plane then write the plane out
                while (exit)
                {
                    //read in the plane
                    inSemaphore.Signal();
                    inBuffer.Read(ref this.planeInfo);
                    panel.BackColor = Color.Pink;

                    //move the plane the lenght of the panel
                    for (int i = 1; i <= length; i++)
                    {
                        panel.Invalidate();
                        this.movePlane(xDelta, yDelta);
                        Thread.Sleep(planeInfo.Speed);
                    }

                    //write the plane out
                    outSemaphore.Wait();
                    outBuffer.Write(planeInfo);

                    //rest the panel
                    this.zeroPlane();
                    this.planeInfo.Colour = Color.LightGreen;
                    panel.BackColor = Color.LightGreen;
                    panel.Invalidate();
                }

            }

        }// end class JunctionPanel

        /////////////////
        //Run Way Panel//
        /////////////////

        public class RunWay : PlanePanel
        {

            private Semaphore inSemaphore;
            private Semaphore outSemaphore;
            private Buffer inBuffer;
            private Buffer outBuffer0, outBuffer1, outBuffer2, outBuffer3, outBuffer4, outBuffer5, outBuffer6, outBuffer7, outBuffer8, outBuffer9, outBuffer10;

            //constructor
            public RunWay(int direction,
                               Panel panel,
                               Semaphore inSemaphore,
                               Semaphore outSemaphore,
                               Buffer inBuffer,
                               Buffer outBuffer0, Buffer outBuffer1, Buffer outBuffer2, Buffer outBuffer3, Buffer outBuffer4, Buffer outBuffer5, Buffer outBuffer6, Buffer outBuffer7, Buffer outBuffer8, Buffer outBuffer9, Buffer outBuffer10,
                               ref Plane planeInfo)
            {
                this.direction = direction;
                this.panel = panel;
                this.panel.Paint += new PaintEventHandler(this.panel_Paint);
                this.inSemaphore = inSemaphore;
                this.outSemaphore = outSemaphore;
                this.inBuffer = inBuffer;
                this.outBuffer0 = outBuffer0;
                this.outBuffer1 = outBuffer1;
                this.outBuffer2 = outBuffer2;
                this.outBuffer3 = outBuffer3;
                this.outBuffer4 = outBuffer4;
                this.outBuffer5 = outBuffer5;
                this.outBuffer6 = outBuffer6;
                this.outBuffer7 = outBuffer7;
                this.outBuffer8 = outBuffer8;
                this.outBuffer9 = outBuffer9;
                this.outBuffer10 = outBuffer10;
                this.planeInfo = planeInfo;
                this.zeroPlane();
            }

            //thread start
            public override void Start()
            {
                int length = 0;
                int speed = 0;

                //find the length of the panel
                if (direction == 2 || direction == 4)
                    length = (panel.Height - 30) / 10;
                else
                    length = (panel.Width - 30) / 10;

                panel.BackColor = Color.LightGreen;

                // loop through to read in, draw/move plane then write the plane out
                while (true)
                {
                    // read in plane
                    inSemaphore.Signal();
                    inBuffer.Read(ref this.planeInfo);

                    //if not the default color then draw/move plane then write the plane out
                    if (planeInfo.Colour != Color.LightGreen)
                    {

                        panel.BackColor = Color.Pink;

                        //move the plane the lenght of the panel
                        for (int i = 1; i <= length; i++)
                        {
                            panel.Invalidate();
                            this.movePlane(xDelta, yDelta);
                            
                            //if taking off the speed up else move at plane speed 
                            if (planeInfo.Destination != 0)
                                speed = planeInfo.Speed;
                            else
                                speed = panel.Width - (i * 10);

                            Thread.Sleep(speed);
                        }

                        //if plane not taking off then move into next panel else write to take off panel
                        if (planeInfo.Destination != 0)
                        {
                            outSemaphore.Wait();
                            outBuffer0.Write(planeInfo);
                        }

                        // if buffer one full write to buffer two and so on
                        else if (planeInfo.Destination == 0)
                            if (outBuffer1.Empty)
                                outBuffer1.Write(planeInfo);
                            else if (outBuffer2.Empty)
                                outBuffer2.Write(planeInfo);
                            else if (outBuffer3.Empty)
                                outBuffer3.Write(planeInfo);
                            else if (outBuffer4.Empty)
                                outBuffer4.Write(planeInfo);
                            else if (outBuffer5.Empty)
                                outBuffer5.Write(planeInfo);
                            else if (outBuffer6.Empty)
                                outBuffer6.Write(planeInfo);
                            else if (outBuffer7.Empty)
                                outBuffer7.Write(planeInfo);
                            else if (outBuffer8.Empty)
                                outBuffer8.Write(planeInfo);
                            else if (outBuffer9.Empty)
                                outBuffer9.Write(planeInfo);
                            else if (outBuffer10.Empty)
                                outBuffer10.Write(planeInfo);
                        
                        //rest panel                        
                        this.planeInfo.Colour = Color.LightGreen;
                        this.zeroPlane();
                        panel.BackColor = Color.LightGreen;
                        panel.Invalidate();
                    }
                }
            }
        }// end class Run Way Panel

        /////////////////////////
        //Arrival Run Way Panel//
        /////////////////////////

        public class ArrivalRunWay : PlanePanel
        {
            private Semaphore inSemaphore;
            private Semaphore outSemaphore;
            private Buffer inBuffer0, inBuffer1, inBuffer2, inBuffer3, inBuffer4, inBuffer5, inBuffer6, inBuffer7, inBuffer8, inBuffer9;
            private Buffer    outBuffer;
            private Button btn;
            private bool locked = true;
            private RadioButton rad0, rad1, rad2, rad3;
            
            //constuctor
            public ArrivalRunWay(int direction,
                               Panel panel,
                               Semaphore inSemaphore,
                               Semaphore outSemaphore,
                               Buffer inBuffer0, Buffer inBuffer1, Buffer inBuffer2, Buffer inBuffer3, Buffer inBuffer4, Buffer inBuffer5, Buffer inBuffer6, Buffer inBuffer7, Buffer inBuffer8, Buffer inBuffer9, 
                               Buffer outBuffer,
                               ref Plane planeInfo,
                               Button btn,
                               RadioButton rad0,RadioButton rad1,RadioButton rad2,RadioButton rad3)
            {
                this.direction = direction;
                this.panel = panel;
                this.panel.Paint += new PaintEventHandler(this.panel_Paint);
                this.inSemaphore = inSemaphore;
                this.outSemaphore = outSemaphore;
                this.inBuffer0 = inBuffer0;
                this.inBuffer1 = inBuffer1;
                this.inBuffer2 = inBuffer2;
                this.inBuffer3 = inBuffer3;
                this.inBuffer4 = inBuffer4;
                this.inBuffer5 = inBuffer5;
                this.inBuffer6 = inBuffer6;
                this.inBuffer7 = inBuffer7;
                this.inBuffer8 = inBuffer8;
                this.inBuffer9 = inBuffer9;
                this.outBuffer = outBuffer;
                this.planeInfo = planeInfo;
                this.btn = btn;
                this.rad0 = rad0;
                this.rad1 = rad1;
                this.rad2 = rad2;
                this.rad3 = rad3;
                this.btn.Click += new System.
                      EventHandler(this.btn_Click);
                this.zeroPlane();
            }

            //button event listinor
            private void btn_Click(object sender, System.EventArgs e)
            {
                //invert value of the locked
                locked = !locked;

                //set color of the button
                if (inBuffer0.Empty && inBuffer1.Empty && inBuffer2.Empty && inBuffer3.Empty
                    && inBuffer4.Empty && inBuffer5.Empty && inBuffer6.Empty && inBuffer7.Empty
                    && inBuffer8.Empty && inBuffer9.Empty)

                    this.btn.BackColor = Color.LightGreen;
                else
                    this.btn.BackColor = Color.Pink;

                //allow the plane to move
                lock (this)
                {
                    if (!locked)
                        Monitor.Pulse(this);
                }
            }

            //Start thread
            public override void Start()
            {
                int speed = 0;

                //find the length of the panel
                int length = 0;
                if (direction == 2 || direction == 4)
                    length = (panel.Height - 30) / 10;
                else
                    length = (panel.Width - 30) / 10;
                
                //Setup the panel
                Color signal = Color.Red;
                Thread.Sleep(planeInfo.Speed);
                this.zeroPlane();
                panel.BackColor = Color.Pink;
                panel.Invalidate();

                // loop through to read in, draw/move plane then write the plane out
                while (true)
                {
                    inSemaphore.Signal();
                    this.zeroPlane();
                    
                    //read in buffers if first one isn't empty then read it in else move on to the next one
                    if (inBuffer0.Empty == false && planeInfo.Colour == Color.LightGreen)
                    {
                        inBuffer0.Read(ref this.planeInfo);
                        inBufferAfter();
                    }
                    else if (inBuffer1.Empty == false && planeInfo.Colour == Color.LightGreen)
                    {
                        inBuffer1.Read(ref this.planeInfo);
                        inBufferAfter();
                    }
                    else if (inBuffer2.Empty == false && planeInfo.Colour == Color.LightGreen)
                    {
                        inBuffer2.Read(ref this.planeInfo);
                        inBufferAfter();
                    }
                    else if (inBuffer3.Empty == false && planeInfo.Colour == Color.LightGreen)
                    {
                       inBuffer3.Read(ref this.planeInfo);
                       inBufferAfter();
                    }
                    else if (inBuffer4.Empty == false && planeInfo.Colour == Color.LightGreen)
                    {
                        inBuffer4.Read(ref this.planeInfo);
                        inBufferAfter();
                    }
                    else if (inBuffer5.Empty == false && planeInfo.Colour == Color.LightGreen)
                    {
                        inBuffer5.Read(ref this.planeInfo);
                        inBufferAfter();
                    }
                    else if (inBuffer6.Empty == false && planeInfo.Colour == Color.LightGreen)
                    {
                        inBuffer6.Read(ref this.planeInfo);
                        inBufferAfter();
                    }
                    else if (inBuffer7.Empty == false && planeInfo.Colour == Color.LightGreen)
                    {
                        inBuffer7.Read(ref this.planeInfo);
                        inBufferAfter();
                    }
                    else if (inBuffer8.Empty == false && planeInfo.Colour == Color.LightGreen)
                    {
                        inBuffer8.Read(ref this.planeInfo);
                        inBufferAfter();
                    }
                    else if (inBuffer9.Empty == false && planeInfo.Colour == Color.LightGreen)
                    {
                        inBuffer9.Read(ref this.planeInfo);
                        inBufferAfter();
                    }

                    //if not default color then move plane/write plane out
                    if (planeInfo.Colour != Color.LightGreen)
                    {
                        panel.BackColor = Color.Pink;

                        //move the plane for then lenght of the panel
                        for (int i = 1; i <= length; i++)
                        {
                            panel.Invalidate();
                            this.movePlane(xDelta, yDelta);
                            //decrease the speed of the landing plane
                            speed = panel.Width + (i * 10);
                            Thread.Sleep(speed);
                        }

                        lock (this)
                        {
                            while (locked)
                            {
                                Monitor.Wait(this);
                            }
                        }
                         
                        //wirte plane out
                        outSemaphore.Wait();

                            // check the radio buttons before leaveing the arrivale area
                            if (rad0.Checked)
                                planeInfo.Destination = 0;
                            else if (rad1.Checked)
                                planeInfo.Destination = 1;
                            else if (rad2.Checked)
                                planeInfo.Destination = 2;
                            else if (rad3.Checked)
                                planeInfo.Destination = 3;

                        outBuffer.Write(planeInfo);

                        //rest panel
                        locked = !locked;
                        this.zeroPlane();
                        this.planeInfo.Colour = Color.LightGreen;
                        panel.BackColor = Color.LightGreen;
                        panel.Invalidate();
                    }
                }
            }

                private void inBufferAfter()
                {
                    this.btn.BackColor = Color.Pink;
                    panel.BackColor = Color.Pink;
                    panel.Invalidate();
                }
            
        }// end class Arrival Run Way Panel
        
        //////////////
        ///Junction///
        //////////////
        
        public class Junction : PlanePanel
        {
            private Buffer inBuffer, outBuffer, hubBuffer;
            private Semaphore hubSemaphore, outSemaphore, inSemaphore;
            private int hubNumber;

            //Constructor
            public Junction(int direction,
                Panel panel,
                Buffer inBuffer,
                Buffer outBuffer,
                Buffer hubBuffer,
                Semaphore inSemaphore,
                Semaphore outSemaphore,
                Semaphore hubSemaphore,
                int hubNumber,
                ref Plane planeInfo)
            {
                this.direction = direction;
                this.panel = panel;
                this.inBuffer = inBuffer;
                this.outBuffer = outBuffer;
                this.hubBuffer = hubBuffer;
                this.hubSemaphore = hubSemaphore;
                this.inSemaphore = inSemaphore;
                this.outSemaphore = outSemaphore;
                this.hubNumber = hubNumber;
                this.planeInfo = planeInfo;
                this.panel.Paint += new PaintEventHandler(this.panel_Paint);
            }

            public override void Start()
            {
                //find the length of the panel
                int length = 0;
                if (direction == 2 || direction == 4)
                    length = (panel.Height - 30) / 10;
                else
                    length = (panel.Width - 30) / 10;

                //setup panel
                panel.BackColor = Color.LightGreen;
                this.zeroPlane();
                panel.Invalidate();

                // loop through to read in, draw/move plane then write the plane out
                while (true)
                {
                    // read in plane
                    inSemaphore.Signal();
                    inBuffer.Read(ref planeInfo);
                    panel.BackColor = Color.Pink;
                    panel.Invalidate();

                    //move the plane the lenght of the panel
                    for (int i = 1; i <= length; i++)
                    {
                        this.movePlane(xDelta, yDelta);
                        Thread.Sleep(planeInfo.Speed);
                        panel.Invalidate();
                    }            
                    
                    //if next panel equal to hub number then write out else move to othe panel
                    if (inBuffer.PlaneInfo.Destination == hubNumber)
                    {
                        // wait for panel to be free and then write out data
                        hubSemaphore.Wait();
                        hubBuffer.Write(planeInfo);
                    }
                    else
                    {
                        //write out the plane
                        outSemaphore.Wait();
                        outBuffer.Write(planeInfo);
                    }

                    //rest the panel
                    planeInfo.Colour = Color.LightGreen;
                    panel.BackColor = Color.LightGreen;
                    this.zeroPlane();
                    panel.Invalidate();
                    

                } 
            }
        }// end class Junction 

        /////////////////
        ///Hub Section///
        /////////////////

        public class HubSection : PlanePanel
        {
            private Semaphore outSemaphore;
            private Semaphore inSemaphore;
            private Buffer outBuffer;
            private Buffer inBuffer; 
            private Button btn;
            private bool locked = true;

            //Constructor
            public HubSection(int direction,
                                         Panel panel,
                                         Semaphore inSemaphore,
                                         Semaphore outSemaphore,
                                         Buffer inBuffer,
                                         Buffer outBuffer,
                                         Button btn,
                                         ref Plane planeInfo)
                {

                    base.direction = direction;
                    base.panel = panel;
                    base.panel.Paint += new PaintEventHandler(this.panel_Paint);
                    base.planeInfo = planeInfo;
                    this.inSemaphore = inSemaphore;
                    this.outSemaphore = outSemaphore;
                    this.inBuffer = inBuffer;
                    this.outBuffer = outBuffer;
                    this.btn = btn;
                    this.btn.Click += new System.
                                          EventHandler(this.btn_Click);
                    this.zeroPlane();


                }
                
                //button event listinor
                private void btn_Click(object sender,
                                       System.EventArgs e)
                {
                    //invert value of the locked
                    locked = !locked;

                    //set color of the button
                    if(inBuffer.Empty)
                        this.btn.BackColor = Color.LightGreen;
                    else
                        this.btn.BackColor = Color.Pink;

                    //allow the plane to move
                    lock (this)
                    {
                        if (!locked)
                            Monitor.Pulse(this);
                    }
                }
                public override void Start()
                {
                    //find the length of the panel
                    int length = 0;
                    if (direction == 2 || direction == 4)
                        length = (panel.Height - 30) / 10;
                    else
                        length = (panel.Width - 30) / 10;
                    
                    //setup panel
                    panel.BackColor = Color.Pink;
                    zeroPlane();
                    panel.Invalidate();

                    // loop through to read in, draw/move plane then write the plane out
                    while (true)
                    {
                        lock (this)
                        {
                            while (locked)
                            {
                                Monitor.Wait(this);
                            }
                        }
                        if (planeInfo.Colour != Color.LightGreen)
                        {
                            //move the plane for then lenght of the panel
                            for (int i = 1; i <= length; i++)
                            {
                                this.movePlane(xDelta, yDelta);
                                Thread.Sleep(planeInfo.Speed);
                                panel.Invalidate();
                            }
                            
                            //write out to ne panel
                            outSemaphore.Wait();
                            outBuffer.Write(planeInfo);
                            inSemaphore.Signal();

                            //rest panel
                            planeInfo.Colour = Color.LightGreen;
                            panel.BackColor = Color.LightGreen;
                            panel.Invalidate();
                            
                            //changes the direction of the panel
                            switchDirection();

                            //read new plane in
                            inBuffer.Read(ref planeInfo);
                            panel.BackColor = Color.Pink;
                            zeroPlane();
                            panel.Invalidate();

                            //move the plane for then lenght of the panel
                            for (int i = 1; i <= length; i++)
                            {
                                this.movePlane(xDelta, yDelta);
                                Thread.Sleep(planeInfo.Speed);
                                panel.Invalidate();
                            }

                            //changes the direction of the panel
                            switchDirection();
                            locked = !locked;
                            btn.BackColor = Color.Pink;
                            planeInfo.Destination = 0;

                        }
                    } 
                }

        }// end class Hub Section 

    }
}

