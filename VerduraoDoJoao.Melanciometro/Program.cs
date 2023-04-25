using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace VerduraoDoJoao.Melanciometro
{
    //public class Cadastro
    //{
    //    public void CadastrarPlaca(string Placa)
    //    {
            
    //    }
    //    public void CadastrarNome(string Nome)
    //    {

    //    }
    //}
    internal class Program
    {
        static void Main(string[] args)
        {
            float CarrinhoComumKg = 0;
            float CarrinhoBabyKg = 0;
            string resposta = "";
            string escolhaMstr;
            double PrecoComum = 5.50;
            double PrecoBaby = 8.56;
            string DiaSemana;
            bool DiaLoop = true;
            bool MenuLoop = true;  
            // Dictionary <string, string> placa = new Dictionary <string, string> ();
            int tentativas = 0;
            string usuario;
            string senha;
            bool bSenha = true;
            StringBuilder senhasb = new StringBuilder ();
            StringBuilder Placa = new StringBuilder();
            string asterisco = "";
            string placa3L = null;
            int placa1N;
            string placa1L = null;
            int placa2N;
            bool placaCadastrada = false;
            string SoN = "";

            // Login
            while (tentativas < 3)
            {
                Console.Clear();
                Console.WriteLine("VOCE TEM " + (3 - tentativas) + " TENTATIVAS PARA INSERIR SUAS CREDENCIAIS");
                Console.WriteLine("\n");
                Console.WriteLine("Digite o nome de usuário e tecle enter:");
                Console.WriteLine("USUÁRIO:");
                usuario = Console.ReadLine();
                usuario = usuario.ToLower();

                Console.Clear();
                Console.WriteLine("VOCE TEM " + (3 - tentativas) + " TENTATIVAS PARA INSERIR SUAS CREDENCIAIS");
                Console.WriteLine("\n");
                Console.WriteLine("Digite a senha e tecle enter:");
                Console.WriteLine("SENHA:");
                asterisco = "*";

                while (bSenha == true)
                {

                    var tecla = Console.ReadKey(true);
                    if (tecla.Key == ConsoleKey.Enter)
                    {
                        bSenha = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("VOCE TEM " + (3 - tentativas) + " TENTATIVAS PARA INSERIR SUAS CREDENCIAIS");
                        Console.WriteLine("\n");
                        Console.WriteLine("Digite a senha e tecle enter:");
                        senhasb.Append(tecla.KeyChar);
                        Console.WriteLine("SENHA:" + asterisco);
                        asterisco += "*";
                    }
                }
                senha = senhasb.ToString();

                if (usuario == "joao" && senha == "123")
                {
                    Console.WriteLine("Login efetuado com sucesso.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Usuário ou senha errados!");
                    tentativas += 1;
                    senhasb.Clear();
                    bSenha = true;
                    asterisco = "";
                    Console.ReadKey();
                }

                if (tentativas == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("NÚMERO DE TENTATIVAS EXCEDIDO!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            string PlacaStr = null;
            string promocao = null;
            string dia = "";
            bool cadastrando = true;
            bool digitosPlaca = true;
            
            // Loja e cadastro
            while (MenuLoop == true) 
            {
                Console.Clear();
                Console.WriteLine("MENU DE OPÇOES - Digite a opção e tecle enter. \n");
                Console.WriteLine("1 - Realizar compras");
                Console.WriteLine("2 - Cadastrar a placa do caminhão para realizar a entrega.");
                Console.WriteLine("3 - Sair");
                resposta = Console.ReadLine();


                if(placaCadastrada == true)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Placa do caminhão que fará a entrega: " + PlacaStr);
                }
                

                if (resposta == "1")
                {
                    while (DiaLoop == true)
                    {
                        Console.Clear();
                        Console.WriteLine("Bem vindo ao Verdurao do Joao!");
                        Console.WriteLine("Digite o dia da semana que deseja realizar sua compra:");
                        Console.WriteLine("\n");
                        Console.WriteLine("1 - Segunda"); // Desconto de 1%
                        Console.WriteLine("2 - TERÇA VERDE 15% DE DESCONTO");
                        Console.WriteLine("3 - QUARTA VERDE 17% DE DESCONTO");
                        Console.WriteLine("4 - Quinta"); // Desconto de 2%
                        Console.WriteLine("5 - Sexta"); // Desconto de 3%
                        DiaSemana = Console.ReadLine();
                        
                        switch (DiaSemana)
                        {
                            case "1":
                                Console.Clear(); 
                                Console.WriteLine("Hoje é Segunda");
                                PrecoBaby = PrecoBaby * (1 - 0.01);
                                PrecoComum = PrecoComum * (1 - 0.01);
                                DiaLoop = false;
                                dia = "Segunda";
                                break;

                            case "2":
                                Console.Clear(); 
                                Console.WriteLine("Hoje é a Terça Verde e temos promoção de 15%!");
                                PrecoBaby = PrecoBaby * (1 - 0.15);
                                PrecoComum = PrecoComum * (1 - 0.15);
                                DiaLoop = false;
                                dia = "Terça";
                                promocao = "15%";
                                break;

                            case "3":
                                Console.Clear(); 
                                Console.WriteLine("Hoje é a Quarta Verde e temos promoção de 17%!");
                                PrecoBaby = PrecoBaby * (1 - 0.17);
                                PrecoComum = PrecoComum * (1 - 0.17);
                                DiaLoop = false;
                                dia = "Quarta";
                                promocao = "17%";
                                
                                break;

                            case "4":
                                Console.Clear(); 
                                Console.WriteLine("Hoje é Quinta");
                                PrecoBaby = PrecoBaby * (1 - 0.02);
                                PrecoComum = PrecoComum * (1 - 0.02);
                                DiaLoop = false;
                                dia = "Quinta";
                                break;

                            case "5":
                                Console.Clear(); 
                                Console.WriteLine("Hoje é Sexta");
                                PrecoBaby = PrecoBaby * (1 - 0.03);
                                PrecoComum = PrecoComum * (1 - 0.03);
                                DiaLoop = false;
                                dia = "Sexta";
                                break;

                            default:
                                Console.WriteLine("Deve ser um número de 1 a 5, digite novamente!");
                                DiaSemana = Console.ReadLine();
                                break;
                        }
                    }
                    
                    
                    //COMPRANDO

                    bool comprando = true;
                    

                    while (comprando == true)
                    {
                        Console.Clear();
                        if (promocao != null)
                        {
                            Console.WriteLine("Hoje é " + dia + " Verde e temos " + promocao + " de desconto!");
                        }
                        else
                        {
                            Console.WriteLine("Hoje é " + dia + " Feira");
                        }

                        float ArredPrecoC = (float)(Math.Round((double)PrecoComum, 2));
                        float ArredPrecoB = (float)(Math.Round((double)PrecoBaby, 2));

                        Console.WriteLine("\n");
                        Console.WriteLine(" 1 - Melancia Comum | R$" + ArredPrecoC + " | " + CarrinhoComumKg + " kg no carrinho");
                        Console.WriteLine(" 2 - Melancia Baby  | R$" + ArredPrecoB + " | " + CarrinhoBabyKg + " kg no carrinho");
                        Console.WriteLine(" 3 - Finalizar compra");
                        Console.WriteLine("\n");
                        Console.WriteLine("Digite o número da opção e tecle enter (1 a 3)");
                        escolhaMstr = Console.ReadLine();

                        switch (escolhaMstr)
                        {
                            case "1":
                                try
                                {
                                    Console.WriteLine("Quantos Kg de Melancia Comum deseja adicionar ou remover do carrinho? (numero negativo para remover)");
                                    CarrinhoComumKg += float.Parse(Console.ReadLine());
                                    if (CarrinhoComumKg < 0.0)
                                    {
                                        Console.WriteLine("O valor no carrinho deve ser uma valor positivo!");
                                        CarrinhoComumKg = 0;
                                        Console.ReadKey();
                                        break;
                                    }

                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Digite um valor válido de Kg!");
                                    Console.ReadKey();
                                }
                                break;

                            case "2":
                                try
                                {
                                    Console.WriteLine("Quantos Kg de Melancia Baby deseja adicionar ou remover do carrinho? (numero negativo para remover)");
                                    CarrinhoBabyKg += float.Parse(Console.ReadLine());
                                    if (CarrinhoBabyKg < 0.0)
                                    {
                                        Console.WriteLine("O valor no carrinho deve ser uma valor positivo!");
                                        CarrinhoComumKg = 0;
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Digite um valor válido de Kg!");
                                    Console.ReadKey();
                                }
                                break;

                            case "3":
                                Console.Clear();
                                Console.WriteLine("O seu carrinho contem: \n");
                                Console.WriteLine("Melancia Comum       "+ CarrinhoComumKg +"Kg   |   R$" + CarrinhoComumKg * ArredPrecoC);
                                Console.WriteLine("Melancia Baby        "+ CarrinhoBabyKg +"Kg   |   R$" + CarrinhoBabyKg * ArredPrecoB);
                                Console.WriteLine("----------------------------------------------- \n");
                                Console.WriteLine("TOTAL: R$" + ((CarrinhoComumKg * ArredPrecoC) + (CarrinhoBabyKg * ArredPrecoB)));
                                Console.WriteLine("\n");
                                Console.WriteLine("\n");
                                
                                if (placaCadastrada == true)
                                {
                                    Console.WriteLine("Placa do caminhão que fará a entrega: " + PlacaStr);
                                    Console.WriteLine("\n Obrigado pela preferência e volte sempre!");
                                    Console.ReadKey();
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.WriteLine("Deseja cadastrar um caminhão para realizar a entrega? (S/N)");
                                    SoN = Console.ReadLine();
                                    SoN = SoN.ToLower();
                                    
                                    switch (SoN)
                                    {
                                        case "s": 
                                            resposta = "2";
                                            comprando = false;
                                            cadastrando = true;
                                            escolhaMstr = "3";
                                            break;
                                        
                                        case "n": 
                                            Console.WriteLine("Obrigado pela preferência, volte sempre!");
                                            Console.ReadKey();
                                            comprando = false;
                                            MenuLoop = false;
                                            break;
                                        
                                        default:
                                            Console.WriteLine("Resposta deve ser S/N !");
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                                break;

                            default:
                                Console.WriteLine("Digite 1, 2 ou 3!");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
                    
                else if(resposta == "2") // Cadastrar caminhão
                {
                    while (cadastrando == true)
                    {
                        placa3L = "";
                        placa1N = 0;
                        placa1L = "";
                        placa2N = 0;

                        Console.Clear();
                        Console.WriteLine("CADASTRANDO PLACA\n");
                        Console.WriteLine("Digite a placa do caminhão no modelo Mercosul");
                        Console.WriteLine("Modelo: (AAA1A11)");
                        Console.WriteLine("Placa a ser cadastrada: " + Placa.ToString().ToUpper());
                        // Console.WriteLine("numero de digitos placa: " + Placa.Length);

                        var tecla = Console.ReadKey(true);
                        if (tecla.Key == ConsoleKey.Enter)
                        {
                            cadastrando = false;
                            try
                            {
                                // Console.Clear();
                                // Console.WriteLine("Placa Cadastrada!");
                                //Console.WriteLine("Placa: " + PlacaStr);
                                placa3L = PlacaStr.Substring(0, 3);
                                placa1N = int.Parse(PlacaStr.Substring(3, 1));
                                placa1L = PlacaStr.Substring(4, 1);
                                placa2N = int.Parse(PlacaStr.Substring(5)); // output 11, corta da pos 5 pra tras incluindo a 5
                                // Console.WriteLine(placa3L + "\n" + placa1N + "\n" + placa1L + "\n" + placa2N);
                                placaCadastrada = true;
                                
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\n ERRO - A placa deve seguir o formato AAA1A11 de letras (A) e numeros (1) !");
                                Console.ReadKey();
                                Placa.Clear();
                                cadastrando = true;
                                placaCadastrada = false;
                                break;
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("\n ERRO - A placa deve seguir o formato AAA1A11 de letras (A) e numeros (1) !");
                                Console.ReadKey();
                                Placa.Clear();
                                cadastrando = true;
                                placaCadastrada = false;
                                break;
                            }      
                        }
                        if (tecla.Key == ConsoleKey.Backspace && Placa.Length > 0)
                        {
                            Placa.Remove(Placa.Length - 1, 1);
                        }
                        else if (tecla.Key != ConsoleKey.Backspace && tecla.Key != ConsoleKey.Enter)
                        {
                            Placa.Append(tecla.KeyChar);
                            // Console.WriteLine("Placa a ser cadastrada: " + Placa);
                            PlacaStr = Placa.ToString();
                            PlacaStr = PlacaStr.ToUpper();
                        }
                        if (PlacaStr.Length > 7)
                        {
                            Console.WriteLine("\n ERRO - Placa a ser cadastrada deve ter no máximo 7 dígitos!: ");
                            Console.WriteLine("Pressione qualquer tecla para continuar.");
                            Placa.Remove(Placa.Length - 1, 1);
                            PlacaStr = Placa.ToString();
                            Console.ReadKey();
                            Placa.Clear();
                            Console.Clear();
                        }
                        
                        if (placaCadastrada == true) // placa cadastrada
                        {
                            Console.Clear();
                            Console.WriteLine("Placa cadastrada com sucesso!\n");
                            Console.WriteLine("Placa: " + PlacaStr);
                            cadastrando = false;
                            Console.ReadKey();
                        }
                    }
                }
                else if (resposta == "3")
                {
                    Console.WriteLine("Até a próxima!");
                    Console.ReadKey(true);
                    break;
                }
                else
                {
                    Console.WriteLine("Digite 1, 2 ou 3!");
                    resposta = Console.ReadLine();

                }
            }     
        }
    }
}