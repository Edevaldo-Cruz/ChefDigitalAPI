using System;

namespace ChefDigital.Entities.Enums
{
    public enum OrderStatusEnum
    {
        Canceled = -1,
        Processing = 1,
        InPreparation = 2,
        ReadyToShip = 3,
        Sent = 4,
    }

    public static class OrderStatusMessages
    {
        public static string GetMessage(OrderStatusEnum status)
        {
            switch (status)
            {
                case OrderStatusEnum.Canceled:
                    return @"Lamentamos profundamente ter que informar que seu pedido foi cancelado. Compreendemos que isso possa ser frustrante e 
                             gostaríamos de esclarecer os motivos desse cancelamento.
                            Para obter informações detalhadas sobre o cancelamento do seu pedido, solicitamos que entre em contato conosco o mais rápido possível.
                            Nossa equipe de atendimento ao cliente está disponível para fornecer explicações e orientações sobre como proceder a partir deste
                            ponto.

                            Entendemos que situações de cancelamento podem ser decepcionantes, e estamos comprometidos em ajudá-lo a resolver qualquer 
                            problema que tenha ocorrido. Sua satisfação é importante para nós, e estamos à disposição para auxiliá-lo no que for necessário.
                            
                            Pedimos desculpas por qualquer inconveniência que essa situação possa ter causado e agradecemos por escolher nossa empresa. 
                            Valorizamos a confiança que depositou em nós e esperamos poder servi-lo melhor em futuras oportunidades.
                            
                            Por favor, entre em contato conosco para mais informações sobre o cancelamento e como podemos ajudar a resolver qualquer 
                            problema pendente.";

                case OrderStatusEnum.Processing:
                    return @"Gostaríamos de informar que seu pedido encontra-se atualmente em processo de processamento. 
                             Estamos trabalhando diligentemente para garantir que seu pedido seja tratado com a maior atenção aos detalhes e eficiência.
                             Nosso objetivo é garantir a entrega dos produtos de alta qualidade que você escolheu o mais rápido possível. 
                             Estamos comprometidos em garantir que tudo esteja em ordem antes de prosseguir com a entrega.

                             Fique tranquilo, estaremos monitorando de perto o progresso do seu pedido e entraremos em contato 
                             assim que houver qualquer atualização relevante. 

                             Caso tenha alguma dúvida ou necessite de informações adicionais, não hesite em nos contatar. 
                             Nossa equipe de atendimento ao cliente estará à disposição para ajudar no que for necessário.

                             Agradecemos pela sua paciência e confiança em nossa empresa. 
                             Valorizamos sua preferência e esperamos que sua experiência de compra conosco seja excelente.";

                case OrderStatusEnum.InPreparation:
                    return @"Gostaríamos de informar que seu pedido encontra-se atualmente em fase de preparação. 
                             Nossa equipe está trabalhando diligentemente para assegurar que sua encomenda seja cuidadosamente preparada e embalada.
                             Durante essa etapa, nossos especialistas estão garantindo que todos os itens selecionados estejam em perfeito estado e 
                             devidamente acondicionados para garantir sua satisfação. Estamos empenhados em assegurar que a qualidade de sua compra seja impecável.
                             Por favor, aguarde um pouco mais enquanto finalizamos a preparação da sua encomenda. Estamos comprometidos em garantir que você receba
                             exatamente o que solicitou, da melhor forma possível.

                             Fique à vontade para entrar em contato conosco se tiver alguma dúvida ou necessitar de informações adicionais. 
                             Nossa equipe de atendimento ao cliente está disponível para ajudar no que for necessário.

                             Agradecemos por escolher nossa empresa para suas compras e valorizamos a confiança que depositou em nós. 
                             Estamos ansiosos para entregar sua encomenda com perfeição.
                             Mantenha-se informado e, em breve, entraremos em contato com atualizações adicionais sobre o status do seu pedido.";

                case OrderStatusEnum.ReadyToShip:
                    return @"Temos o prazer de informar que seu pedido está agora pronto para ser enviado. 
                             Nossa equipe dedicou cuidadosa atenção e esforço para garantir que sua encomenda esteja completa e pronta para chegar até você.
                             Nos próximos passos, estaremos gerando o número de rastreamento do envio, que permitirá que você acompanhe o progresso da 
                             entrega de sua compra. Este número será enviado a você em breve, juntamente com informações detalhadas sobre a transportadora 
                             responsável.

                             Fique atento à sua caixa de entrada, pois estaremos enviando a atualização com o número de rastreamento assim que estiver disponível.
                             Isso permitirá que você acompanhe sua encomenda a cada passo do caminho.
                             Caso tenha alguma dúvida ou necessite de assistência adicional, nossa equipe de atendimento ao cliente está pronta para ajudar. 
                             Sua satisfação é nossa prioridade número um.

                             Agradecemos por escolher nossa empresa e esperamos que sua experiência de compra seja excepcional. 
                             Aguardamos ansiosamente entregar seu pedido com sucesso.
                             
                             Mantenha-se informado e, em breve, entraremos em contato com o número de rastreamento e mais detalhes sobre o envio.";

                case OrderStatusEnum.Sent:
                    return @"É com grande satisfação que informamos que seu pedido foi enviado com sucesso. Sua encomenda está a caminho e estamos ansiosos 
                             para que você a receba em breve.
                            Para facilitar o acompanhamento da entrega, fornecemos o número de rastreamento da sua encomenda: [Inserir Número de Rastreamento].
                            Você pode utilizar esse número para acompanhar o status da entrega em tempo real no site da transportadora.
                            A equipe de entrega está empenhada em assegurar que sua compra chegue até você com segurança e no prazo estimado. 

                            Se tiver alguma dúvida ou precisar de suporte durante o processo de entrega, não hesite em nos contatar. 
                            Nossa equipe de atendimento ao cliente está à disposição para auxiliá-lo.

                            Agradecemos por escolher nossa empresa para suas compras. Valorizamos sua confiança e esperamos que sua experiência de compra 
                            seja excepcional. Seu feedback é importante para nós, e estamos comprometidos em proporcionar o melhor atendimento possível.
                            Mantenha-se informado e acompanhe o status da entrega usando o número de rastreamento fornecido. 
                            Agradecemos por sua preferência e esperamos que sua encomenda chegue em perfeitas condições.";

                default:
                    throw new ArgumentOutOfRangeException(nameof(status), "Status de pedido desconhecido.");
            }
        }
    }
}
