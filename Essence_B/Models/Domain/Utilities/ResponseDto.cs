namespace Essence_B.Models.Domain.Utilities
{
    public class ResponseDto
    {
        public bool status { get; set; }
        public string? messagge { get; set; }
        public dynamic? data { get; set; }
        public ResponseDto(bool st, string msj, dynamic? dt = null) { 
            status =st;
            messagge = msj;
            data = dt;
        }
        
    }
}
