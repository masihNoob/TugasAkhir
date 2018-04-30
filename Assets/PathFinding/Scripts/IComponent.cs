using System.Collections.Generic;

public interface IComponent{
    List<BaseStat> Stats { get; set; }
	void PerformAttack();
}
