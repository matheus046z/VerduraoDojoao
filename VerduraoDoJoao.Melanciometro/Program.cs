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
            string resposta;
            string escolhaMstr;
            double PrecoComum = 5.50;
            double PrecoBaby = 8.56;
            string DiaSemana;
            bool DiaLoop = true;
            bool LojaLoop = true;
            //string placa = " ";
            int digitosPlaca;
            Dictionary <string, string> placa = new Dictionary <string, string> ();
            int tentativas = 0;
            string usuario;
            string senha;
            bool bUsuario = true;
            bool bSenha = true;
            StringBuilder senhasb = new StringBuilder ();
            StringBuilder usuariosb = new StringBuilder();
            string asterisco = "";

            // Login
            while (tentativas < 3)
            {
                Console.Clear();
                Console.WriteLine("VOCE TEM " + (3 - tentativas) + " TENTATIVAS PARA INSERIR SUAS CREDENCIAIS");
                Console.WriteLine("\n");
                Console.WriteLine("Digite o nome de usuário e tecle enter:");
                Console.WriteLine("USUÁRIO:");

                while (bUsuario == true)
                {

                    var tecla = Console.ReadKey(true);
                    if (tecla.Key == ConsoleKey.Enter)
                    {
                        bUsuario = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("VOCE TEM " + (3 - tentativas) + " TENTATIVAS PARA INSERIR SUAS CREDENCIAIS");
                        Console.WriteLine("\n");
                        Console.WriteLine("Digite o nome de usuário e tecle enter:");
                        usuariosb.Append(tecla.KeyChar);
                        asterisco += "*";
                        Console.WriteLine("USUÁRIO:" + asterisco);

                    }
                }
                usuario = usuariosb.ToString();

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
                    usuariosb.Clear();
                    senhasb.Clear();
                    bUsuario = true;
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

            Console.WriteLine("1 - Realizar compras");
            Console.WriteLine("2 - Cadastrar um caminhão e motorista para realizar a entrega."); // Cadastrar com readkey letra por letra
            Console.WriteLine("3 - Sair");
            resposta = Console.ReadLine();

            string promocao = null;
            string dia = "";

            // Loja e cadastro
            while (LojaLoop == true) 
            {
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
                                Console.WriteLine("Deseja cadastrar um caminhão para realizar a entrega? (S/N)");
                                string SoN = Console.ReadLine();
                                SoN = SoN.ToLower();
                                while (true)
                                {
                                    if (SoN == "s")
                                    {
                                        resposta = "2";
                                        comprando = false;
                                        break;
                                    }
                                    else if (SoN == "n")
                                    {
                                        Console.WriteLine("Obrigado pela preferência, volte sempre!");
                                        Console.ReadKey();
                                        comprando = false;
                                        LojaLoop = false;

                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("A resposta deve ser S ou N");
                                        SoN = Console.ReadLine();
                                        SoN = SoN.ToLower();
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
                    Console.WriteLine("CADASTRANDO CAMINHÃO");
                    Console.WriteLine("IR PARA A LOJA ?"); // Se sim, resposta = 1, no proximo loop volta pra loja
                    Console.ReadKey();
                    Environment.Exit(0);

                }
                else if (resposta == "3")
                {
                    Console.WriteLine("Que pena, até a próxima");
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