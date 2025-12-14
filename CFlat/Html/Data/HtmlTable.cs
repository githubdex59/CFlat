using System.Net.Sockets;

namespace CFlat.Html.Data;

public class HtmlTable : HtmlElement
{
    public HtmlTable(List<string> cols, List<List<string>> rows, string css)
    {
        _cols = cols;
        _rows = rows;
        
        _children = new List<HtmlElement>();
        _css = css;
        _attributes = new Attributes();
    }
    
    public HtmlTable(List<string> cols, List<List<string>> rows) : this(cols, rows, "")
    {
        
    }

    public List<HtmlElement> _children { get; set; }
    public string _css { get; set; }
    public Attributes _attributes { get; set; }

    private List<string> _cols;
    private List<List<string>> _rows;

    private void AddRow(params string[] cols)
    {
        List<string> row = new List<string>();
        for (int i = 0; i < _cols.Count; i++)
        {
            row.Add(_cols[i]);
        }
        _rows.Add(row);
    }



    public string Render(ref NetworkStream stream)
    {
        return Render();
    }
    public string Render()
    {
        string html = "";
        
        html += $"<table style=\"{_css}\">\n";
        
        html += $"<thead>\n";
        html += $"<tr>\n";
        foreach (string col in _cols)
        {
            html += $"<th scope=\"col\">{col}</th>\n";
        }
        html += $"</tr>\n";
        html += $"</thead>\n";
        
        html += $"<tbody>\n";

        foreach (var row in _rows)
        {
            html += $"<tr>\n";

            foreach (string col in row)
            {
                if (col == row[0])
                {
                    html += $"<th scope=\"row\">{col}</th>\n";
                    continue;
                }
                html += $"<td>{col}</td>\n";
            }
            
            html += $"</tr>\n";
        }
        
        html += $"</tbody>\n";
        
        html += $"</table>\n";

        return html;
    }
}