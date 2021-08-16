using Microsoft.AspNetCore.Mvc.Rendering;

using Publix.Risk.IncidentIntake.UI.Pipelines;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.UI.Models
{
    public static class DropdownHelper
    {
        public async static Task<List<SelectListItem>> GetDropdownValues(this IHTTPClientHelper hTTPClientHelper, int codeTypeId)
        {
            if (codeTypeId<0)
            {
                throw new ArgumentNullException(nameof(codeTypeId));
            }
            var selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem { Value = "", Text = "" });
            var result = await hTTPClientHelper.GetAsync<Codes>($"api/codes/{codeTypeId}");
            foreach (var item in result.codes)
            {
                selectListItems.Add(new SelectListItem
                {
                    Value = item.codeText.codeTextId.ToString(),
                    Text = item.codeText.description

                });
            }
            return selectListItems;
        }
    }
}
