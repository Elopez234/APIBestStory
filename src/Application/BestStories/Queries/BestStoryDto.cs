using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBestSc.Application.BestStories.Queries;
public class BestStoryDto
{
    public string? Title { get; init; }
    public string? Uri { get; init; } = null;
    public string? PostedBy { get; init; } = null;
    public string? Time { get; init; } = null;
    public int Score { get; init; }
    public int CommentCount { get; init; }



}
