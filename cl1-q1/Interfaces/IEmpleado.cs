using cl1_q1.Models;

namespace cl1_q1.Interfaces
{
    public interface IEmpleado
    {
        List<Empleado> GetEmpleados();

        Empleado GetEmpleado(int id);

        int AddEmpleado(Empleado empleado);

        int UpdateEmpleado(Empleado empleado);

        int DeleteEmpleado(int id);
    }
}
