using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FalknerCountyJuvenileCourt.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FalknerCountyJuvenileCourt.Pages;

public class IndexModel : PageModel
{


     private readonly CourtContext _context;

    public IndexModel(CourtContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGetArrestedRaceDistributionDataAsync()
    {
        try
        {
            var raceCounts = _context.Juveniles
                .GroupBy(c => c.Race.Name)
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
    public async Task<IActionResult> OnGetGenderDistributionDataAsync()
    {

        try
        {
            var genderCounts = _context.Juveniles
                .GroupBy(j => j.Gender.Name)
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
    public async Task<IActionResult> OnGetAgeDistributionDataAsync()
    {
        try
        {
        var ageGroups = _context.Juveniles
            .GroupBy(j => (j.Age - 1) / 3 * 3)
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
    public async Task<IActionResult> OnGetIntakeDecisionDistributionDataAsync()
    {

        try
        {
            var IntakeDecisionCounts = _context.Crimes
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
    public async Task<IActionResult> OnGetRiskDistributionDataAsync()
    {

         try
    {
        var RiskCounts = _context.Crimes
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
    public async Task<IActionResult> OnGetSchoolDistributionDataAsync()
    {

        try
        {
            var SchoolCounts = _context.Crimes
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
    public async Task<IActionResult> OnGetFilingDecisionDistributionDataAsync()
    {

        try
        {
            var FilingDecisionCounts = _context.Crimes
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
    public async Task<IActionResult> OnGetDelinquencySchoolDistributionDataAsync()
    {

        try
        {
            var delinquencyschool = _context.Crimes
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
    public async Task<IActionResult> OnGetDelinquencyRaceDistributionDataAsync()
    {

        try
        {

            var delinquencyrace = _context.Crimes
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
    public async Task<IActionResult> OnGetDelinquencyGenderDistributionDataAsync()
    {

        try
        {
            var delinquencygender = _context.Crimes
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
    public async Task<IActionResult> OnGetDelinquencyAgeDistributionDataAsync()
    {
        try
        {
        var delinquencyage = _context.Crimes
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
    public async Task<IActionResult> OnGetRaceDistributionDataAsync()
    {

        try {
            var raceCounts = _context.Crimes
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
    public async Task<IActionResult> OnGetAdGenderDistributionDataAsync()
    {

        try
        {
            var genderCounts = _context.Crimes
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
    public async Task<IActionResult> OnGetAdAgeDistributionDataAsync()
    {
        try
        {
        var ageGroups = _context.Crimes
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
    public async Task<IActionResult> OnGetAdRiskDistributionDataAsync()
    {

      try
      {
        var AdRiskCounts = _context.Crimes
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
    public async Task<IActionResult> OnGetDrugGenderDistributionDataAsync()
    {

        try
        {
            var druggenderCounts = _context.Crimes
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
    public async Task<IActionResult> OnGetDrugRaceDistributionDataAsync()
    {

        try
        {
            var drugraceCounts = _context.Crimes
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
