using System;


public class Observer<T>
{

    private T value;
    
    public event Action OnChange;
    public event Action<T> OnValueChange; 

    public T Value
    {
        get => value;
        set
        {
            if (!Equals(this.value , value))
            {
                this.value = value;
                OnChange?.Invoke();
                OnValueChange?.Invoke(this.value);
            }
        }
    }

    public Observer(T initialValue = default)
    {
        value = initialValue;
    }

    public void Callingtener()
    {
        OnChange?.Invoke();
        OnValueChange?.Invoke(this.value);
    }
}
