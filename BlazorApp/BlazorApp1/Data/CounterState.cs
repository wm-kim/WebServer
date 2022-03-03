namespace BlazorApp1.Data
{
	// 논리적으로 보면 CounterState라는 서비스를 만들어서 관리하면 전역에서 사용하는 느낌으로 할 수 있겠다.
	// Program쪽에 Singleton/Transient/Scoped중 택1, 이 경우는 Scoped를 해야 유저별로 관리가 될거임
	public class CounterState
	{
		int _count = 0;
		// public int Count { get; set; }

		public Action OnStateChanged;

		public int Count
		{ 
			get
			{
				return _count;
			}

			set
			{
				_count = value;
				Refresh();
			}
		}

		void Refresh()
		{
			OnStateChanged?.Invoke();
		}
	}
}
