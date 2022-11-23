using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fanorona91G.Models
{
    public class Nodo
    {
        public string State { get; set; } = "222201111";
        public List<Nodo> Children { get; set; } = new List<Nodo>();
        public int Value { get; set; }
        public int Whites { get; set; } = 4;
        public int Blacks { get; set; } = 4;
        public int Turn { get; set; } = 1;
        private bool maximizing = false;
      //  private bool isFirstTime = true;
        private int openWhites;
        private int openBlacks;

        //Matriz multidimensional
        private static readonly int[,] lines =
                new int[,] {
                //Matriz bidimensional de 3 filas y 3 columnas
                //El numero 2 representa una ficha negra y el numero 1 represena una ficha blanca y el numero 0 es vacio.
                { 2,2,2},
                { 2,0,1},
                { 1,1,1}
                };

        public bool WinnerWhitesOrBlacks(int whites, int blacks)
        {
            if (whites == 0)
            {
                return true;
            }
            else if (blacks == 0)
            {
                return true;
            }
            return false;
        }

        public void ChildrenGenerate(int turn, int depth)
        {

            Turn = turn;
            for (int i = 0; i < 9; i++)
            {
                //if (State[i] == '0' && Children.Count <= 4)
                //{
                //    var arrayState = State.ToCharArray();
                //     arrayState[i] = char.Parse(Turn.ToString());
                //    Nodo son2 = new Nodo()
                //    {
                //        Whites = 4,
                //        Blacks = 3,
                //        State = "220211011",
                //    };
                //    Children.Add(son2);
                //    Nodo son3 = new Nodo()
                //    {
                //        Whites = 4,
                //        Blacks = 3,
                //        State = "202211101",
                //    };
                //    Children.Add(son3);
                //    Nodo son4 = new Nodo()
                //    {
                //        Whites = 4,
                //        Blacks = 3,
                //        State = "022211110",
                //        isFirstTime = false
                //    };
                //}
                if (State[i] == '0')
                {
                    var arrayState = State.ToCharArray();
                    //Ver a que posicion quiere mover
                    if (i == 0)
                    {
                        //Ver si de donde esta puede moverse a la posicion 0
                        if (arrayState[1] == char.Parse(Turn.ToString()) || arrayState[3] == char.Parse(Turn.ToString())
                                    || arrayState[4] == char.Parse(Turn.ToString()))
                        {
                            //Ver en que posicion estaba
                            int posicion = arrayState[1] == char.Parse(Turn.ToString()) ? 1 :
                                arrayState[3] == char.Parse(Turn.ToString()) ? 3 : 4;
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 1)
                            {
                                if (arrayState[2] == '1' && Turn == 2)
                                {
                                    Whites--;
                                    arrayState[2] = '0';
                                    arrayState[1] = '0';



                                }
                                if (arrayState[2] == '2' && Turn == 1)
                                {
                                    arrayState[2] = '0';
                                    arrayState[1] = '0';
                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 3)
                            {
                                if (arrayState[6] == '1' && Turn == 2)
                                {
                                    arrayState[6] = '0';
                                    arrayState[3] = '0';



                                    Whites--;
                                }
                                if (arrayState[6] == '2' && Turn == 1)
                                {
                                    arrayState[6] = '0';
                                    arrayState[3] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 4)
                            {
                                if (arrayState[8] == '1' && Turn == 2)
                                {
                                    arrayState[8] = '0';
                                    arrayState[4] = '0';
                                    Whites--;
                                }
                                if (arrayState[8] == '2' && Turn == 1)
                                {
                                    arrayState[8] = '0';
                                    arrayState[4] = '0';



                                    Blacks--;
                                }
                            }
                        }
                    }




                    if (i == 1)
                    {
                        //Ver si de donde esta puede moverse a la posicion 0
                        if (arrayState[4] == char.Parse(Turn.ToString()) || arrayState[0] == char.Parse(Turn.ToString())
                                || arrayState[2] == char.Parse(Turn.ToString()))
                        {
                            //Ver en que posicion estaba
                            int posicion = arrayState[4] == char.Parse(Turn.ToString()) ? 4 :
                                arrayState[0] == char.Parse(Turn.ToString()) ? 0 : 2;
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 4)
                            {
                                if (arrayState[7] == '1' && Turn == 2)
                                {
                                    arrayState[7] = '0';
                                    arrayState[4] = '0';



                                    Whites--;
                                }
                                if (arrayState[7] == '2' && Turn == 1)
                                {
                                    arrayState[7] = '0';
                                    arrayState[4] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 0)
                            {
                                if (arrayState[2] == '1' && Turn == 2)
                                {
                                    arrayState[2] = '0';
                                    arrayState[0] = '0';



                                    Whites--;
                                }
                                if (arrayState[2] == '2' && Turn == 1)
                                {
                                    arrayState[2] = '0';
                                    arrayState[0] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 2)
                            {
                                if (arrayState[0] == '1' && Turn == 2)
                                {
                                    arrayState[0] = '0';
                                    arrayState[2] = '0';



                                    Whites--;
                                }

                                if (arrayState[0] == '2' && Turn == 1)
                                {
                                    arrayState[0] = '0';
                                    arrayState[2] = '0';



                                    Blacks--;
                                }
                            }
                        }
                    }




                    if (i == 2)
                    {
                        if (arrayState[4] == char.Parse(Turn.ToString()) || arrayState[1] == char.Parse(Turn.ToString())
                        || arrayState[5] == char.Parse(Turn.ToString()))
                        {
                            //Ver en que posicion estaba
                            int posicion = arrayState[4] == char.Parse(Turn.ToString()) ? 4 :
                                arrayState[1] == char.Parse(Turn.ToString()) ? 1 : 5;
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 4)
                            {
                                if (arrayState[6] == '1' && Turn == 2)
                                {
                                    arrayState[6] = '0';
                                    arrayState[4] = '0';



                                    Whites--;
                                }
                                if (arrayState[6] == '2' && Turn == 1)
                                {
                                    arrayState[6] = '0';
                                    arrayState[4] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 1)
                            {
                                if (arrayState[0] == '1' && Turn == 2)
                                {
                                    arrayState[0] = '0';
                                    arrayState[1] = '0';



                                    Whites--;
                                }
                                if (arrayState[0] == '2' && Turn == 1)
                                {
                                    arrayState[0] = '0';
                                    arrayState[1] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 5)
                            {
                                if (arrayState[8] == '1' && Turn == 2)
                                {
                                    arrayState[8] = '0';
                                    arrayState[5] = '0';



                                    Whites--;
                                }
                                if (arrayState[8] == '2' && Turn == 1)
                                {
                                    arrayState[8] = '0';
                                    arrayState[5] = '0';



                                    Blacks--;
                                }

                            }
                        }
                    }




                    if (i == 3)
                    {
                        if (arrayState[4] == char.Parse(Turn.ToString()) || arrayState[0] == char.Parse(Turn.ToString())
                        || arrayState[6] == char.Parse(Turn.ToString()))
                        {
                            //Ver en que posicion estaba
                            int posicion = arrayState[4] == char.Parse(Turn.ToString()) ? 4 :
                                arrayState[0] == char.Parse(Turn.ToString()) ? 0 : 6;
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 4)
                            {
                                if (arrayState[5] == '1' && Turn == 2)
                                {
                                    arrayState[5] = '0';
                                    arrayState[4] = '0';



                                    Whites--;
                                }
                                if (arrayState[5] == '2' && Turn == 1)
                                {
                                    arrayState[5] = '0';
                                    arrayState[4] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 0)
                            {
                                if (arrayState[6] == '1' && Turn == 2)
                                {
                                    arrayState[6] = '0';
                                    arrayState[0] = '0';



                                    Whites--;
                                }
                                if (arrayState[6] == '2' && Turn == 1)
                                {
                                    arrayState[6] = '0';
                                    arrayState[0] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 6)
                            {
                                if (arrayState[0] == '1' && Turn == 2)
                                {
                                    arrayState[0] = '0';
                                    arrayState[6] = '0';



                                    Whites--;
                                }
                                if (arrayState[0] == '2' && Turn == 1)
                                {
                                    arrayState[0] = '0';
                                    arrayState[6] = '0';



                                    Blacks--;
                                }
                            }
                        }
                    }




                    if (i == 4)
                    {
                        if (arrayState[0] == char.Parse(Turn.ToString()) || arrayState[1] == char.Parse(Turn.ToString())
                        || arrayState[2] == char.Parse(Turn.ToString()) || arrayState[3] == char.Parse(Turn.ToString())
                        || arrayState[5] == char.Parse(Turn.ToString()) || arrayState[6] == char.Parse(Turn.ToString())
                        || arrayState[7] == char.Parse(Turn.ToString()) || arrayState[8] == char.Parse(Turn.ToString()))



                        {
                            //Ver en que posicion estaba
                            int posicion = arrayState[0] == char.Parse(Turn.ToString()) ? 0 : arrayState[1] == char.Parse(Turn.ToString())
                            ? 1 : arrayState[2] == char.Parse(Turn.ToString()) ? 2 : arrayState[3] == char.Parse(Turn.ToString()) ? 3 :
                                arrayState[5] == char.Parse(Turn.ToString()) ? 5 :
                            arrayState[6] == char.Parse(Turn.ToString()) ? 6 : arrayState[7] == char.Parse(Turn.ToString()) ? 7 : 8;
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 0)
                            {
                                if (arrayState[8] == '1' && Turn == 2)
                                {
                                    arrayState[8] = '0';
                                    arrayState[0] = '0';



                                    Whites--;
                                }
                                if (arrayState[8] == '2' && Turn == 1)
                                {
                                    arrayState[8] = '0';
                                    arrayState[0] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 1)
                            {
                                if (arrayState[7] == '1' && Turn == 2)
                                {
                                    arrayState[7] = '0';
                                    arrayState[1] = '0';



                                    Whites--;
                                }
                                if (arrayState[7] == '2' && Turn == 1)
                                {
                                    arrayState[7] = '0';
                                    arrayState[1] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 2)
                            {
                                if (arrayState[6] == '1' && Turn == 2)
                                {
                                    arrayState[6] = '0';
                                    arrayState[2] = '0';



                                    Whites--;
                                }
                                if (arrayState[6] == '2' && Turn == 1)
                                {
                                    arrayState[6] = '0';
                                    arrayState[2] = '0';



                                    Blacks--;
                                }
                            }
                            if (posicion == 3)
                            {
                                if (arrayState[5] == '1' && Turn == 2)
                                {
                                    arrayState[5] = '0';
                                    arrayState[3] = '0';



                                    Whites--;
                                }
                                if (arrayState[5] == '2' && Turn == 1)
                                {
                                    arrayState[5] = '0';
                                    arrayState[3] = '0';



                                    Blacks--;
                                }
                            }
                            if (posicion == 5)
                            {
                                if (arrayState[3] == '1' && Turn == 2)
                                {
                                    arrayState[3] = '0';
                                    arrayState[5] = '0';



                                    Whites--;
                                }
                                if (arrayState[3] == '2' && Turn == 1)
                                {
                                    arrayState[3] = '0';
                                    arrayState[5] = '0';



                                    Blacks--;
                                }
                            }
                            if (posicion == 6)
                            {
                                if (arrayState[2] == '1' && Turn == 2)
                                {
                                    arrayState[2] = '0';
                                    arrayState[6] = '0';



                                    Whites--;
                                }
                                if (arrayState[2] == '2' && Turn == 1)
                                {
                                    arrayState[2] = '0';
                                    arrayState[6] = '0';



                                    Blacks--;
                                }
                            }
                            if (posicion == 7)
                            {
                                if (arrayState[1] == '1' && Turn == 2)
                                {
                                    arrayState[1] = '0';
                                    arrayState[7] = '0';



                                    Whites--;
                                }
                                if (arrayState[1] == '2' && Turn == 1)
                                {
                                    arrayState[1] = '0';
                                    arrayState[7] = '0';



                                    Blacks--;
                                }
                            }
                            if (posicion == 8)
                            {
                                if (arrayState[0] == '1' && Turn == 2)
                                {
                                    arrayState[0] = '0';
                                    arrayState[8] = '0';



                                    Whites--;
                                }
                                if (arrayState[0] == '2' && Turn == 1)
                                {
                                    arrayState[0] = '0';
                                    arrayState[8] = '0';



                                    Blacks--;
                                }
                            }
                        }
                    }




                    if (i == 5)
                    {
                        if (arrayState[4] == char.Parse(Turn.ToString()) || arrayState[2] == char.Parse(Turn.ToString())
                        || arrayState[8] == char.Parse(Turn.ToString()))
                        {
                            //Ver en que posicion estaba
                            int posicion = arrayState[4] == char.Parse(Turn.ToString()) ? 4 :
                            arrayState[2] == char.Parse(Turn.ToString()) ? 2 : 8;
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 4)
                            {
                                if (arrayState[3] == '1' && Turn == 2)
                                {
                                    arrayState[3] = '0';
                                    arrayState[4] = '0';



                                    Whites--;
                                }
                                if (arrayState[3] == '2' && Turn == 1)
                                {
                                    arrayState[3] = '0';
                                    arrayState[4] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 2)
                            {
                                if (arrayState[8] == '1' && Turn == 2)
                                {
                                    arrayState[8] = '0';
                                    arrayState[2] = '0';



                                    Whites--;
                                }
                                if (arrayState[8] == '2' && Turn == 1)
                                {
                                    arrayState[8] = '0';
                                    arrayState[2] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 8)
                            {
                                if (arrayState[2] == '1' && Turn == 2)
                                {
                                    arrayState[2] = '0';
                                    arrayState[8] = '0';



                                    Whites--;
                                }
                                if (arrayState[2] == '2' && Turn == 1)
                                {
                                    arrayState[2] = '0';
                                    arrayState[8] = '0';



                                    Blacks--;
                                }
                            }
                        }
                    }




                    if (i == 6)
                    {
                        if (arrayState[7] == char.Parse(Turn.ToString()) || arrayState[3] == char.Parse(Turn.ToString())
                        || arrayState[4] == char.Parse(Turn.ToString()))
                        {
                            //Ver en que posicion estaba
                            int posicion = arrayState[7] == char.Parse(Turn.ToString()) ? 7 :
                            arrayState[3] == char.Parse(Turn.ToString()) ? 3 : 4;
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 7)
                            {
                                if (arrayState[8] == '1' && Turn == 2)
                                {
                                    arrayState[8] = '0';
                                    arrayState[7] = '0';



                                    Whites--;
                                }
                                if (arrayState[8] == '2' && Turn == 1)
                                {
                                    arrayState[8] = '0';
                                    arrayState[7] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 3)
                            {
                                if (arrayState[0] == '1' && Turn == 2)
                                {
                                    arrayState[0] = '0';
                                    arrayState[3] = '0';



                                    Whites--;
                                }
                                if (arrayState[0] == '2' && Turn == 1)
                                {
                                    arrayState[0] = '0';
                                    arrayState[3] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 4)
                            {
                                if (arrayState[2] == '1' && Turn == 2)
                                {
                                    arrayState[2] = '0';
                                    arrayState[4] = '0';



                                    Whites--;
                                }
                                if (arrayState[2] == '2' && Turn == 1)
                                {
                                    arrayState[2] = '0';
                                    arrayState[4] = '0';



                                    Blacks--;
                                }
                            }
                        }
                    }




                    if (i == 7)
                    {
                        if (arrayState[4] == char.Parse(Turn.ToString()) || arrayState[6] == char.Parse(Turn.ToString())
                        || arrayState[8] == char.Parse(Turn.ToString()))
                        {
                            //Ver en que posicion estaba
                            int posicion = arrayState[4] == char.Parse(Turn.ToString()) ? 4 :
                            arrayState[6] == char.Parse(Turn.ToString()) ? 6 : 8;
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 4)
                            {
                                if (arrayState[1] == '1' && Turn == 2)
                                {
                                    arrayState[1] = '0';
                                    arrayState[4] = '0';



                                    Whites--;
                                }
                                if (arrayState[1] == '2' && Turn == 1)
                                {
                                    arrayState[1] = '0';
                                    arrayState[4] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 6)
                            {
                                if (arrayState[8] == '1' && Turn == 2)
                                {
                                    arrayState[8] = '0';
                                    arrayState[6] = '0';



                                    Whites--;
                                }
                                if (arrayState[8] == '2' && Turn == 1)
                                {
                                    arrayState[8] = '0';
                                    arrayState[6] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por acercamiento 
                            if (posicion == 8)
                            {
                                if (arrayState[6] == '1' && Turn == 2)
                                {
                                    arrayState[6] = '0';
                                    arrayState[8] = '0';



                                    Whites--;
                                }
                                if (arrayState[6] == '2' && Turn == 1)
                                {
                                    arrayState[6] = '0';
                                    arrayState[8] = '0';



                                    Blacks--;
                                }
                            }
                        }
                    }




                    if (i == 8)
                    {
                        if (arrayState[7] == char.Parse(Turn.ToString()) || arrayState[4] == char.Parse(Turn.ToString())
                        || arrayState[5] == char.Parse(Turn.ToString()))
                        {
                            //Ver en que posicion estaba
                            int posicion = arrayState[7] == char.Parse(Turn.ToString()) ? 7 :
                            arrayState[4] == char.Parse(Turn.ToString()) ? 4 : 5;
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 7)
                            {
                                if (arrayState[6] == '1' && Turn == 2)
                                {
                                    arrayState[6] = '0';
                                    arrayState[7] = '0';



                                    Whites--;
                                }
                                if (arrayState[6] == '2' && Turn == 1)
                                {
                                    arrayState[6] = '0';
                                    arrayState[7] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 4)
                            {
                                if (arrayState[0] == '1' && Turn == 2)
                                {
                                    arrayState[0] = '0';
                                    arrayState[4] = '0';



                                    Whites--;
                                }
                                if (arrayState[0] == '2' && Turn == 1)
                                {
                                    arrayState[0] = '0';
                                    arrayState[4] = '0';



                                    Blacks--;
                                }
                            }
                            //Eliminacion de pieza por alejamiento 
                            if (posicion == 5)
                            {
                                if (arrayState[2] == '1' && Turn == 2)
                                {
                                    arrayState[2] = '0';
                                    arrayState[5] = '0';



                                    Whites--;
                                }
                                if (arrayState[2] == '2' && Turn == 1)
                                {
                                    arrayState[2] = '0';
                                    arrayState[5] = '0';



                                    Blacks--;
                                }
                            }

                        }
                    }
                    arrayState[i] = char.Parse(Turn.ToString());
                    Nodo son = new Nodo()
                    {
                        Whites = Whites,
                        Blacks = Blacks,
                        State = new string(arrayState),
                     //  isFirstTime = false
                    };
                    if (depth > 1 && !WinnerWhitesOrBlacks(Whites, Blacks))
                    {
                        MinMax(son, depth, !maximizing);
                        //1 es blancas y 2 negras
                        //ChangeTurn(Turn);
                        son.ChildrenGenerate((turn == 1 ? turn = 2 : turn = 1), depth - 1);
                        //Empieza el maximizin en false porque se empieza minimizando
                    }
                    Children.Add(son);
                }
            }
        }
        public void ValueCalculate(int turno)
        {
            if (FinalGame)
            {
                Value = (WinnerWhitesOrBlacks(Whites, Blacks)) ? int.MaxValue : int.MinValue;
            }
            else
            {
                if (turno == 1)
                {
                    openWhites = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        //El primer numero en la matriz te dice el conjunto de elementos
                        //El segundo numero en la matriz te dice en que posicion del conjunto de elementos
                        if (State[Nodo.lines[i, 0]] == '0' || State[Nodo.lines[i, 1]] == '0' || State[Nodo.lines[i, 2]] == '0')
                        {
                            openWhites += 1;
                        }
                        else
                        {
                            openWhites += 0;
                        }
                    }
                    Value = openWhites - openBlacks;
                    Turn = 2;
                    openWhites = 0;
                    openBlacks = 0;
                }
                else
                {
                    openBlacks = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (State[Nodo.lines[i, 0]] == '0' || State[Nodo.lines[i, 1]] == '0' || State[Nodo.lines[i, 2]] == '0')
                        {
                            openBlacks += 1;
                        }
                        else
                        {
                            openBlacks += 0;
                        }
                    }
                    Value = openBlacks - openWhites;
                    Turn = 1;
                    openWhites = 0;
                    openBlacks = 0;
                }
            }
        }
        public override string ToString()
        {
            return State.ToString();
        }
        public bool FinalGame
        {
            get { return WinnerWhitesOrBlacks(Whites, Blacks); }
        }
        public int MinMax(Nodo nodo, int depth, bool maximizingToPlayer)
        {
            if (depth == 0 || FinalGame)
            {
                ValueCalculate(Turn);
                return Value;
            }
            else
            {
                if (maximizingToPlayer)
                {
                    int value = int.MinValue;
                    foreach (var son in Children)
                    {
                        Value = Math.Max(value, MinMax(nodo, depth - 1, !maximizingToPlayer));
                    }
                    Value = value;
                    return value;
                }
                else
                {
                    int value = int.MaxValue;
                    foreach (var son in Children)
                    {
                        Value = Math.Min(value, son.MinMax(nodo, depth - 1, maximizingToPlayer));
                    }
                    Value = value;
                    return value;
                }
            }
        }
        public void ChangeTurn(int turn)
        {
            Turn = turn;
            Turn = (Turn == 1) ? Turn = 2 : Turn = 1;
        }
    }
}
