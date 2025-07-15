using System;
using System.Collections.Generic;

namespace TransformerFireApp.Models;

public partial class CalibrationValue
{
    public int Index { get; set; }

    public string ParamName { get; set; }

    public string ParamValue { get; set; }

    public string Comment { get; set; }
}
