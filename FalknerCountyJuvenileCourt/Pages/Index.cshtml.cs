﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FalknerCountyJuvenileCourt.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages;

public class IndexModel : PageModel
{


     private readonly CourtContext _context;

    public IndexModel(CourtContext context)
    {
        _context = context;
    }

    public List<int> Years { get; set; }

    public void OnGetAsync(int? selectedYear)
    {
        
        Years = _context.Crimes.Select(j => j.Date.Value.Year).Distinct().OrderByDescending(y => y).ToList();


        

        
    }

    public async Task<IActionResult> OnGetArrestedRaceDistributionDataAsync(int? selectedYear)
    {
        try
        {
            
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

            Console.WriteLine("selectedYear " + selectedYear);
            


        if (selectedYear.HasValue)
            {

            crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
            }

            var raceCounts = crimesIQ
                .GroupBy(c => c.Juvenile.Race.Name)
                .Select(group => new { Race = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(raceCounts);
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data.")
            {
                StatusCode = 500
            };
        }
    }
    


    public async Task<IActionResult> OnGetGenderDistributionDataAsync(int? selectedYear)
    {

        try
        {
            
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

            Console.WriteLine("selectedYear " + selectedYear);
            


        if (selectedYear.HasValue)
            {

            crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
            }
            
            var genderCounts = crimesIQ
                .GroupBy(j => j.Juvenile.Gender.Name)
                .Select(group => new { Gender = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(genderCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data.")
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetAgeDistributionDataAsync(int? selectedYear)
    {
        try
        {
             IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }

        var ageGroups = crimesIQ
            .GroupBy(j => (j.Juvenile.Age - 1) / 3 * 3)
            .Select(group => new { ageGroups = $"{group.Key + 1}-{group.Key + 3}", Count = group.Count() })
            .ToList();

            return new JsonResult(ageGroups);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetIntakeDecisionDistributionDataAsync(int? selectedYear)
    {

        try
        {
             IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
            var IntakeDecisionCounts = crimesIQ
                .GroupBy(j => j.IntakeDecision.Name)
                .Select(group => new { IntakeDecisionCounts = group.Key, count = group.Count() })
                .ToList();

            return new JsonResult(IntakeDecisionCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetRiskDistributionDataAsync(int? selectedYear)
    {

         try
    {
        IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
        var RiskCounts = crimesIQ
            .Where(j => j.IntakeDecisionID == 3)
            .GroupBy(j => j.Juvenile.Risk.Name)
            .Select(group => new { riskcount = group.Key.ToString(), count = group.Count() })
            .ToList();

        return new JsonResult(RiskCounts);
    }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetSchoolDistributionDataAsync(int? selectedYear)
    {

        try
        {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
            var SchoolCounts = crimesIQ
                .GroupBy(j => j.School.Name)
                .Select(group => new { schoolCount = group.Key, count = group.Count() })
                .ToList();

            return new JsonResult(SchoolCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetFilingDecisionDistributionDataAsync(int? selectedYear)
    {

        try
        {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
            var FilingDecisionCounts = crimesIQ
                .GroupBy(j => j.FilingDecision.Name)
                .Select(group => new { filingdecisioncount = group.Key, count = group.Count() })
                .ToList();

            return new JsonResult(FilingDecisionCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDelinquencySchoolDistributionDataAsync(int? selectedYear)
    {

        try
        {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
            var delinquencyschool = crimesIQ
                .Where(j => j.FilingDecisionID == 1)
                .GroupBy(j => j.School.Name)
                .Select(group => new { delinquencyschool = group.Key, Count = group.Count() })
                .ToList();
            
            Console.WriteLine(delinquencyschool);

            return new JsonResult(delinquencyschool);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDelinquencyRaceDistributionDataAsync(int? selectedYear)
    {

        try
        {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }

            var delinquencyrace = crimesIQ
                .Where(j => j.FilingDecisionID == 1)
                .GroupBy(j => j.Juvenile.Race.Name)
                .Select(group => new { delinquencyrace = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(delinquencyrace);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDelinquencyGenderDistributionDataAsync(int? selectedYear)
    {

        try
        {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }

            var delinquencygender = crimesIQ
                .Where(j => j.FilingDecisionID == 1)
                .GroupBy(j => j.Juvenile.Gender.Name)
                .Select(group => new { delinquencygender = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(delinquencygender);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data.")
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDelinquencyAgeDistributionDataAsync(int? selectedYear)
    {
        try
        {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
        var delinquencyage = crimesIQ
            .Where(j => j.FilingDecisionID == 1)
            .GroupBy(j => (j.Juvenile.Age - 1) / 3 * 3)
            .Select(group => new { delinquencyage = $"{group.Key + 1}-{group.Key + 3}", Count = group.Count() })
            .ToList();

            return new JsonResult(delinquencyage);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetRaceDistributionDataAsync(int? selectedYear)
    {

        try {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
            var raceCounts = crimesIQ
                .Where(c => c.IntakeDecisionID == 3)
                .GroupBy(j => j.Juvenile.Race.Name)
                .Select(group => new { Race = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(raceCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data.")
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetAdGenderDistributionDataAsync(int? selectedYear)
    {

        try
        {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
            var genderCounts = crimesIQ
                .Where(j => j.IntakeDecisionID == 3)
                .GroupBy(j => j.Juvenile.Gender.Name)
                .Select(group => new { Gender = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(genderCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data.")
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetAdAgeDistributionDataAsync(int? selectedYear)
    {
        try
        {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
        var ageGroups = crimesIQ
            .Where(j => j.IntakeDecisionID == 3)
            .GroupBy(j => (j.Juvenile.Age - 1) / 3 * 3)
            .Select(group => new { ageGroups = $"{group.Key + 1}-{group.Key + 3}", Count = group.Count() })
            .ToList();

            return new JsonResult(ageGroups);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetAdRiskDistributionDataAsync(int? selectedYear)
    {

      try
      {
        IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
        
        var AdRiskCounts = crimesIQ
            .Where(j => j.FilingDecisionID == 1)
            .GroupBy(j => j.Juvenile.Risk.Name)
            .Select(group => new { adriskcount = group.Key.ToString(), count = group.Count() })
            .ToList();

        return new JsonResult(AdRiskCounts);
      }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDrugGenderDistributionDataAsync(int? selectedYear)
    {

        try
        {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
            var druggenderCounts = crimesIQ
                .Where(j => j.DrugCourt == true)
                .GroupBy(j => j.Juvenile.Gender.Name)
                .Select(group => new { druggendercount = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(druggenderCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
    public async Task<IActionResult> OnGetDrugRaceDistributionDataAsync(int? selectedYear)
    {

        try
        {
            IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

                Console.WriteLine("selectedYear " + selectedYear);
            
            if (selectedYear.HasValue)
                {

                crimesIQ = crimesIQ.Where(j => j.Date.Value.Year == selectedYear);
                }
            var drugraceCounts = crimesIQ
                .Where(j => j.DrugCourt == true)
                .GroupBy(j => j.Juvenile.Race.Name)
                .Select(group => new { drugracecount = group.Key, Count = group.Count() })
                .ToList();

            return new JsonResult(drugraceCounts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new JsonResult("An error occurred while processing the data." +ex)
            {
                StatusCode = 500
            };
        }
    }
}