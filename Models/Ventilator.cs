﻿using System.ComponentModel.DataAnnotations;

namespace VentilationCalculator.Models;

//Таблиця вентиляції
public partial class VentilatorTable
{
    public long Id { get; set; }

    [Required]
    public string? PathToFile { get; set; }
    public string Name { get; set; }
    public double Power { get; set; }
    public int Price { get; set; }







}

