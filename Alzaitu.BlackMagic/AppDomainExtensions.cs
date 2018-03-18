using System;

namespace Alzaitu.BlackMagic
{
	public static class AppDomainExtensions
	{
		public static void DoCallBack(this AppDomain domain, Action action)
		{
			domain.DoCallBack(new CrossAppDomainDelegate(action));
		}

		
		public static void DoCallBack<T1>(this AppDomain domain, Action<T1> action, T1 a1)
		{
			domain.SetData("action", new ObjectPlacement<Action<T1>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Action<T1>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				cAction((ObjectPlacement<T1>)arr[0]);
			});
		}

		public static Action<T1> CreateDelegate<T1>(this AppDomain domain, Action<T1> action)
		{
			return (a1) => domain.DoCallBack(action, a1);
		}
		
		public static void DoCallBack<T1, T2>(this AppDomain domain, Action<T1, T2> action, T1 a1, T2 a2)
		{
			domain.SetData("action", new ObjectPlacement<Action<T1, T2>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Action<T1, T2>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1]);
			});
		}

		public static Action<T1, T2> CreateDelegate<T1, T2>(this AppDomain domain, Action<T1, T2> action)
		{
			return (a1, a2) => domain.DoCallBack(action, a1, a2);
		}
		
		public static void DoCallBack<T1, T2, T3>(this AppDomain domain, Action<T1, T2, T3> action, T1 a1, T2 a2, T3 a3)
		{
			domain.SetData("action", new ObjectPlacement<Action<T1, T2, T3>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Action<T1, T2, T3>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2]);
			});
		}

		public static Action<T1, T2, T3> CreateDelegate<T1, T2, T3>(this AppDomain domain, Action<T1, T2, T3> action)
		{
			return (a1, a2, a3) => domain.DoCallBack(action, a1, a2, a3);
		}
		
		public static void DoCallBack<T1, T2, T3, T4>(this AppDomain domain, Action<T1, T2, T3, T4> action, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			domain.SetData("action", new ObjectPlacement<Action<T1, T2, T3, T4>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Action<T1, T2, T3, T4>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3]);
			});
		}

		public static Action<T1, T2, T3, T4> CreateDelegate<T1, T2, T3, T4>(this AppDomain domain, Action<T1, T2, T3, T4> action)
		{
			return (a1, a2, a3, a4) => domain.DoCallBack(action, a1, a2, a3, a4);
		}
		
		public static void DoCallBack<T1, T2, T3, T4, T5>(this AppDomain domain, Action<T1, T2, T3, T4, T5> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			domain.SetData("action", new ObjectPlacement<Action<T1, T2, T3, T4, T5>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Action<T1, T2, T3, T4, T5>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4]);
			});
		}

		public static Action<T1, T2, T3, T4, T5> CreateDelegate<T1, T2, T3, T4, T5>(this AppDomain domain, Action<T1, T2, T3, T4, T5> action)
		{
			return (a1, a2, a3, a4, a5) => domain.DoCallBack(action, a1, a2, a3, a4, a5);
		}
		
		public static void DoCallBack<T1, T2, T3, T4, T5, T6>(this AppDomain domain, Action<T1, T2, T3, T4, T5, T6> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
		{
			domain.SetData("action", new ObjectPlacement<Action<T1, T2, T3, T4, T5, T6>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5), new ObjectPlacement<T6>(ref a6) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Action<T1, T2, T3, T4, T5, T6>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4], (ObjectPlacement<T6>)arr[5]);
			});
		}

		public static Action<T1, T2, T3, T4, T5, T6> CreateDelegate<T1, T2, T3, T4, T5, T6>(this AppDomain domain, Action<T1, T2, T3, T4, T5, T6> action)
		{
			return (a1, a2, a3, a4, a5, a6) => domain.DoCallBack(action, a1, a2, a3, a4, a5, a6);
		}
		
		public static void DoCallBack<T1, T2, T3, T4, T5, T6, T7>(this AppDomain domain, Action<T1, T2, T3, T4, T5, T6, T7> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
		{
			domain.SetData("action", new ObjectPlacement<Action<T1, T2, T3, T4, T5, T6, T7>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5), new ObjectPlacement<T6>(ref a6), new ObjectPlacement<T7>(ref a7) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Action<T1, T2, T3, T4, T5, T6, T7>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4], (ObjectPlacement<T6>)arr[5], (ObjectPlacement<T7>)arr[6]);
			});
		}

		public static Action<T1, T2, T3, T4, T5, T6, T7> CreateDelegate<T1, T2, T3, T4, T5, T6, T7>(this AppDomain domain, Action<T1, T2, T3, T4, T5, T6, T7> action)
		{
			return (a1, a2, a3, a4, a5, a6, a7) => domain.DoCallBack(action, a1, a2, a3, a4, a5, a6, a7);
		}
		
		public static void DoCallBack<T1, T2, T3, T4, T5, T6, T7, T8>(this AppDomain domain, Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
		{
			domain.SetData("action", new ObjectPlacement<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5), new ObjectPlacement<T6>(ref a6), new ObjectPlacement<T7>(ref a7), new ObjectPlacement<T8>(ref a8) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Action<T1, T2, T3, T4, T5, T6, T7, T8>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4], (ObjectPlacement<T6>)arr[5], (ObjectPlacement<T7>)arr[6], (ObjectPlacement<T8>)arr[7]);
			});
		}

		public static Action<T1, T2, T3, T4, T5, T6, T7, T8> CreateDelegate<T1, T2, T3, T4, T5, T6, T7, T8>(this AppDomain domain, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
		{
			return (a1, a2, a3, a4, a5, a6, a7, a8) => domain.DoCallBack(action, a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		public static void DoCallBack<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this AppDomain domain, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)
		{
			domain.SetData("action", new ObjectPlacement<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5), new ObjectPlacement<T6>(ref a6), new ObjectPlacement<T7>(ref a7), new ObjectPlacement<T8>(ref a8), new ObjectPlacement<T9>(ref a9) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4], (ObjectPlacement<T6>)arr[5], (ObjectPlacement<T7>)arr[6], (ObjectPlacement<T8>)arr[7], (ObjectPlacement<T9>)arr[8]);
			});
		}

		public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this AppDomain domain, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
		{
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9) => domain.DoCallBack(action, a1, a2, a3, a4, a5, a6, a7, a8, a9);
		}
		
		public static void DoCallBack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this AppDomain domain, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)
		{
			domain.SetData("action", new ObjectPlacement<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5), new ObjectPlacement<T6>(ref a6), new ObjectPlacement<T7>(ref a7), new ObjectPlacement<T8>(ref a8), new ObjectPlacement<T9>(ref a9), new ObjectPlacement<T10>(ref a10) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4], (ObjectPlacement<T6>)arr[5], (ObjectPlacement<T7>)arr[6], (ObjectPlacement<T8>)arr[7], (ObjectPlacement<T9>)arr[8], (ObjectPlacement<T10>)arr[9]);
			});
		}

		public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> CreateDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this AppDomain domain, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
		{
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) => domain.DoCallBack(action, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
		}
				
		public static TReturn DoCallBack<T1, TReturn>(this AppDomain domain, Func<T1, TReturn> action, T1 a1)
		{
			var ret = default(TReturn);
			domain.SetData("res", new ObjectPlacement<TReturn>(ref ret));
			domain.SetData("action", new ObjectPlacement<Func<T1, TReturn>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Func<T1, TReturn>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				((ObjectPlacement<TReturn>)AppDomain.CurrentDomain.GetData("res")).Value = cAction((ObjectPlacement<T1>)arr[0]);
			});
			return ret;
		}

		public static Func<T1, TReturn> CreateDelegate<T1, TReturn>(this AppDomain domain, Func<T1, TReturn> action)
		{
			return (a1) => domain.DoCallBack(action, a1);
		}
		
		public static TReturn DoCallBack<T1, T2, TReturn>(this AppDomain domain, Func<T1, T2, TReturn> action, T1 a1, T2 a2)
		{
			var ret = default(TReturn);
			domain.SetData("res", new ObjectPlacement<TReturn>(ref ret));
			domain.SetData("action", new ObjectPlacement<Func<T1, T2, TReturn>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Func<T1, T2, TReturn>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				((ObjectPlacement<TReturn>)AppDomain.CurrentDomain.GetData("res")).Value = cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1]);
			});
			return ret;
		}

		public static Func<T1, T2, TReturn> CreateDelegate<T1, T2, TReturn>(this AppDomain domain, Func<T1, T2, TReturn> action)
		{
			return (a1, a2) => domain.DoCallBack(action, a1, a2);
		}
		
		public static TReturn DoCallBack<T1, T2, T3, TReturn>(this AppDomain domain, Func<T1, T2, T3, TReturn> action, T1 a1, T2 a2, T3 a3)
		{
			var ret = default(TReturn);
			domain.SetData("res", new ObjectPlacement<TReturn>(ref ret));
			domain.SetData("action", new ObjectPlacement<Func<T1, T2, T3, TReturn>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Func<T1, T2, T3, TReturn>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				((ObjectPlacement<TReturn>)AppDomain.CurrentDomain.GetData("res")).Value = cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2]);
			});
			return ret;
		}

		public static Func<T1, T2, T3, TReturn> CreateDelegate<T1, T2, T3, TReturn>(this AppDomain domain, Func<T1, T2, T3, TReturn> action)
		{
			return (a1, a2, a3) => domain.DoCallBack(action, a1, a2, a3);
		}
		
		public static TReturn DoCallBack<T1, T2, T3, T4, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, TReturn> action, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			var ret = default(TReturn);
			domain.SetData("res", new ObjectPlacement<TReturn>(ref ret));
			domain.SetData("action", new ObjectPlacement<Func<T1, T2, T3, T4, TReturn>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Func<T1, T2, T3, T4, TReturn>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				((ObjectPlacement<TReturn>)AppDomain.CurrentDomain.GetData("res")).Value = cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3]);
			});
			return ret;
		}

		public static Func<T1, T2, T3, T4, TReturn> CreateDelegate<T1, T2, T3, T4, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, TReturn> action)
		{
			return (a1, a2, a3, a4) => domain.DoCallBack(action, a1, a2, a3, a4);
		}
		
		public static TReturn DoCallBack<T1, T2, T3, T4, T5, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, TReturn> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			var ret = default(TReturn);
			domain.SetData("res", new ObjectPlacement<TReturn>(ref ret));
			domain.SetData("action", new ObjectPlacement<Func<T1, T2, T3, T4, T5, TReturn>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Func<T1, T2, T3, T4, T5, TReturn>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				((ObjectPlacement<TReturn>)AppDomain.CurrentDomain.GetData("res")).Value = cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4]);
			});
			return ret;
		}

		public static Func<T1, T2, T3, T4, T5, TReturn> CreateDelegate<T1, T2, T3, T4, T5, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, TReturn> action)
		{
			return (a1, a2, a3, a4, a5) => domain.DoCallBack(action, a1, a2, a3, a4, a5);
		}
		
		public static TReturn DoCallBack<T1, T2, T3, T4, T5, T6, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, T6, TReturn> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
		{
			var ret = default(TReturn);
			domain.SetData("res", new ObjectPlacement<TReturn>(ref ret));
			domain.SetData("action", new ObjectPlacement<Func<T1, T2, T3, T4, T5, T6, TReturn>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5), new ObjectPlacement<T6>(ref a6) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Func<T1, T2, T3, T4, T5, T6, TReturn>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				((ObjectPlacement<TReturn>)AppDomain.CurrentDomain.GetData("res")).Value = cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4], (ObjectPlacement<T6>)arr[5]);
			});
			return ret;
		}

		public static Func<T1, T2, T3, T4, T5, T6, TReturn> CreateDelegate<T1, T2, T3, T4, T5, T6, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, T6, TReturn> action)
		{
			return (a1, a2, a3, a4, a5, a6) => domain.DoCallBack(action, a1, a2, a3, a4, a5, a6);
		}
		
		public static TReturn DoCallBack<T1, T2, T3, T4, T5, T6, T7, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, T6, T7, TReturn> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
		{
			var ret = default(TReturn);
			domain.SetData("res", new ObjectPlacement<TReturn>(ref ret));
			domain.SetData("action", new ObjectPlacement<Func<T1, T2, T3, T4, T5, T6, T7, TReturn>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5), new ObjectPlacement<T6>(ref a6), new ObjectPlacement<T7>(ref a7) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Func<T1, T2, T3, T4, T5, T6, T7, TReturn>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				((ObjectPlacement<TReturn>)AppDomain.CurrentDomain.GetData("res")).Value = cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4], (ObjectPlacement<T6>)arr[5], (ObjectPlacement<T7>)arr[6]);
			});
			return ret;
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, TReturn> CreateDelegate<T1, T2, T3, T4, T5, T6, T7, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, T6, T7, TReturn> action)
		{
			return (a1, a2, a3, a4, a5, a6, a7) => domain.DoCallBack(action, a1, a2, a3, a4, a5, a6, a7);
		}
		
		public static TReturn DoCallBack<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
		{
			var ret = default(TReturn);
			domain.SetData("res", new ObjectPlacement<TReturn>(ref ret));
			domain.SetData("action", new ObjectPlacement<Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5), new ObjectPlacement<T6>(ref a6), new ObjectPlacement<T7>(ref a7), new ObjectPlacement<T8>(ref a8) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				((ObjectPlacement<TReturn>)AppDomain.CurrentDomain.GetData("res")).Value = cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4], (ObjectPlacement<T6>)arr[5], (ObjectPlacement<T7>)arr[6], (ObjectPlacement<T8>)arr[7]);
			});
			return ret;
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> CreateDelegate<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> action)
		{
			return (a1, a2, a3, a4, a5, a6, a7, a8) => domain.DoCallBack(action, a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		public static TReturn DoCallBack<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9)
		{
			var ret = default(TReturn);
			domain.SetData("res", new ObjectPlacement<TReturn>(ref ret));
			domain.SetData("action", new ObjectPlacement<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5), new ObjectPlacement<T6>(ref a6), new ObjectPlacement<T7>(ref a7), new ObjectPlacement<T8>(ref a8), new ObjectPlacement<T9>(ref a9) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				((ObjectPlacement<TReturn>)AppDomain.CurrentDomain.GetData("res")).Value = cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4], (ObjectPlacement<T6>)arr[5], (ObjectPlacement<T7>)arr[6], (ObjectPlacement<T8>)arr[7], (ObjectPlacement<T9>)arr[8]);
			});
			return ret;
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> CreateDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> action)
		{
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9) => domain.DoCallBack(action, a1, a2, a3, a4, a5, a6, a7, a8, a9);
		}
		
		public static TReturn DoCallBack<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> action, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8, T9 a9, T10 a10)
		{
			var ret = default(TReturn);
			domain.SetData("res", new ObjectPlacement<TReturn>(ref ret));
			domain.SetData("action", new ObjectPlacement<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>>(ref action));
			domain.SetData("arr", new object[]{ new ObjectPlacement<T1>(ref a1), new ObjectPlacement<T2>(ref a2), new ObjectPlacement<T3>(ref a3), new ObjectPlacement<T4>(ref a4), new ObjectPlacement<T5>(ref a5), new ObjectPlacement<T6>(ref a6), new ObjectPlacement<T7>(ref a7), new ObjectPlacement<T8>(ref a8), new ObjectPlacement<T9>(ref a9), new ObjectPlacement<T10>(ref a10) });
			domain.DoCallBack(() =>
			{
				var cAction = ((ObjectPlacement<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>>)AppDomain.CurrentDomain.GetData("action")).Value;
				var arr = (object[])AppDomain.CurrentDomain.GetData("arr");
				((ObjectPlacement<TReturn>)AppDomain.CurrentDomain.GetData("res")).Value = cAction((ObjectPlacement<T1>)arr[0], (ObjectPlacement<T2>)arr[1], (ObjectPlacement<T3>)arr[2], (ObjectPlacement<T4>)arr[3], (ObjectPlacement<T5>)arr[4], (ObjectPlacement<T6>)arr[5], (ObjectPlacement<T7>)arr[6], (ObjectPlacement<T8>)arr[7], (ObjectPlacement<T9>)arr[8], (ObjectPlacement<T10>)arr[9]);
			});
			return ret;
		}

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> CreateDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>(this AppDomain domain, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> action)
		{
			return (a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) => domain.DoCallBack(action, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
		}
			}
}