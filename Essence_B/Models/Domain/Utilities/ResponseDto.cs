namespace Essence_B.Models.Domain.Utilities
{
    public class ResponseDto
    {
        public bool status { get; set; }
        public string? messagge { get; set; }
        public List<object>? data { get; set; }
        public ResponseDto(bool st, string msj, List<object>? dt = null) { 
            status =st;
            messagge = msj;
            data = dt;
        }
        
    }
}
