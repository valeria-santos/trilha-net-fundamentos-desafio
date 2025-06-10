namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;

        private string placa = "";

        private string placaVeiculoRemovido = "";

        private int horas = 0;

        private decimal valorTotal = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Por favor, tente novamente.");
                return;
            }
            else if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Esse veículo já está estacionado.");
                return;
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo {placa} foi adicionado com sucesso.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            placaVeiculoRemovido = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placaVeiculoRemovido))
            {
                Console.WriteLine("Placa inválida. Por favor, tente novamente.");
                return;
            }
            else
            {
                placa = placaVeiculoRemovido;
                Console.WriteLine($"Placa digitada: {placa}");
            }

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string inputHoras = Console.ReadLine();
                if (!int.TryParse(inputHoras, out horas) || horas < 0)
                {
                    Console.WriteLine("Quantidade de horas inválida. Por favor, tente novamente.");
                    return;
                }
                valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                return;
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
