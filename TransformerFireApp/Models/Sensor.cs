using System.ComponentModel.DataAnnotations.Schema;

namespace TransformerFireApp.Models;

public partial class Sensor
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Unit { get; set; }

    public int SignalType { get; set; }

    public float ZeroSignal { get; set; }

    public float SpanSignal { get; set; }

    public float ZeroOutput { get; set; }

    public float SpanOutput { get; set; }

    public string DisplayName { get; set; }

    public string Discription { get; set; }

    // 当前实时信号值
    private float _currentSignal;
    [NotMapped]
    public float CurrentSignal 
    {
        get { return _currentSignal; }
        set 
        { 
            _currentSignal = value;
            // 根据信号类型设置当前输出值
            switch (SignalType)
            {
                case 0: // 模拟信号
                    _currentOutput = ZeroOutput + (SpanOutput - ZeroOutput) * ((_currentSignal - ZeroSignal) / (SpanSignal - ZeroSignal));
                    break;
                case 1: // 数字信号
                    _currentOutput = _currentSignal;
                    break;
                default:
                    throw new InvalidOperationException("未定义的信号类型,请联系系统管理员。");
            }
        }
    }
    // 当前实时输出值
    private float _currentOutput;
    [NotMapped]
    public float CurrentOutput
    {
        get { return _currentOutput; }
    }
}
