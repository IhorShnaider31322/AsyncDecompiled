using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            new Loader().Heller();
            Console.ReadLine();
        }
    }

    //class Loader
    //{
    //    public async void Heller()
    //    {
    //        var res = await GetResult();
    //        Console.WriteLine(res);
    //    }

    //    public async Task<int> GetResult()
    //    {
    //        var res = await Task.Factory.StartNew(() =>
    //        {
    //            return 4 / 2;
    //        });

    //        Thread.Sleep(3000);


    //        return res; //dev31322



    //    }
    //}
	
    internal class Loader
    {
        [/*DebuggerStepThrough,*/ AsyncStateMachine(typeof(StateMachine1))]
        public void Heller()
        {

            StateMachine1 stateMachine1 = new StateMachine1()
            {
                likeThis = this,
                asyncBuilder = AsyncVoidMethodBuilder.Create(),
                state = -1
            };
            stateMachine1.asyncBuilder.Start(ref stateMachine1);
        }

        [CompilerGenerated]
        private sealed class StateMachine1 : IAsyncStateMachine
        {

            public int state;

            public AsyncVoidMethodBuilder asyncBuilder;

            public Loader likeThis;

            private int result;

            private int tempState;

            private TaskAwaiter<int> globalAwaiter;

            void IAsyncStateMachine.MoveNext()
            {
                int num = this.state;
                try
                {
                    TaskAwaiter<int> taskAwaiter;
                    if (num != 0)
                    {
                        taskAwaiter = this.likeThis.GetResult().GetAwaiter();
                        if (!taskAwaiter.IsCompleted)
                        {
                            state = 0;
                            globalAwaiter = taskAwaiter;
                            StateMachine1 stateMachine = this;
                            asyncBuilder.AwaitUnsafeOnCompleted(ref taskAwaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        taskAwaiter = this.globalAwaiter;
                        this.globalAwaiter = default(TaskAwaiter<int>);
                        this.state = -1;
                    }
                    int result = taskAwaiter.GetResult();
                    taskAwaiter = default(TaskAwaiter<int>);
                    this.tempState = result;
                    this.result = this.tempState;
                    Console.WriteLine(this.result);
                }
                catch (Exception exception)
                {
                    this.state = -2;
                    this.asyncBuilder.SetException(exception);
                    return;
                }
                this.state = -2;
                this.asyncBuilder.SetResult();
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        [Serializable]
        private sealed class fc
        {
            public static readonly Loader.fc f9 = new Loader.fc();

            public static Func<int> f9__1_0;

            internal int FooGetResultb__1_0()
            {
                return 2;
            }
        }

        [CompilerGenerated]
        private sealed class StateMachine2 : IAsyncStateMachine
        {
            public int f1__state;

            public AsyncTaskMethodBuilder<int> ft__builder;

            public Loader f4__this;

            private int res5__1;

            private int fs__2;

            private TaskAwaiter<int> fu__1;

            void IAsyncStateMachine.MoveNext()
            {
                int num = this.f1__state;
                int result2;
                try
                {
                    TaskAwaiter<int> taskAwaiter;
                    if (num != 0)
                    {
                        TaskFactory arg_33_0 = Task.Factory;
                        Func<int> arg_33_1;
                        if ((arg_33_1 = Loader.fc.f9__1_0) == null)
                        {
                            arg_33_1 = (Loader.fc.f9__1_0 = new Func<int>(Loader.fc.f9.FooGetResultb__1_0));
                        }
                        taskAwaiter = arg_33_0.StartNew<int>(arg_33_1).GetAwaiter();
                        if (!taskAwaiter.IsCompleted)
                        {
                            this.f1__state = 0;
                            this.fu__1 = taskAwaiter;
                            StateMachine2 FooGetResultd__ = this;
                            this.ft__builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, Loader.StateMachine2>(ref taskAwaiter, ref FooGetResultd__);
                            return;
                        }
                    }
                    else
                    {
                        taskAwaiter = this.fu__1;
                        this.fu__1 = default(TaskAwaiter<int>);
                        this.f1__state = -1;
                    }
                    int result = taskAwaiter.GetResult();
                    taskAwaiter = default(TaskAwaiter<int>);
                    this.fs__2 = result;
                    this.res5__1 = this.fs__2;
                    Thread.Sleep(3000);
                    result2 = this.res5__1;
                }
                catch (Exception exception)
                {
                    this.f1__state = -2;
                    this.ft__builder.SetException(exception);
                    return;
                }
                this.f1__state = -2;
                this.ft__builder.SetResult(result2);
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }



        [/*DebuggerStepThrough,*/ AsyncStateMachine(typeof(StateMachine2))]
        public Task<int> GetResult()
        {
            StateMachine2 stateMachine2 = new StateMachine2()
            {
                f4__this = this,
                ft__builder = AsyncTaskMethodBuilder<int>.Create(),
                f1__state = -1
            };
            AsyncTaskMethodBuilder<int> ft__builder = stateMachine2.ft__builder;
            ft__builder.Start(ref stateMachine2);
            return stateMachine2.ft__builder.Task;
        }
    }


}
